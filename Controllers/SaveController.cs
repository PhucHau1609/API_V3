using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DATN_API.Data;
using DATN_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DATN_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveGame")]
        public async Task<IActionResult> SaveGame([FromBody] SaveData model)
        {
            var existingData = await _context.SaveDatas.FirstOrDefaultAsync(s => s.UserId == model.UserId);

            if (existingData != null)
            {
                // Cập nhật dữ liệu
                existingData.PosX = model.PosX;
                existingData.PosY = model.PosY;
                existingData.PosZ = model.PosZ;
                existingData.Health = model.Health;
            }
            else
            {
                // Thêm mới
                _context.SaveDatas.Add(model);
            }

            await _context.SaveChangesAsync();
            return Ok(new { isSuccess = true, message = "Game saved successfully." });
        }

        [HttpGet("LoadGame/{userId}")]
        public async Task<IActionResult> LoadGame(int userId)
        {
            var saveData = await _context.SaveDatas.FirstOrDefaultAsync(s => s.UserId == userId);

            if (saveData == null)
                return NotFound(new { isSuccess = false, message = "No save data found." });

            return Ok(new
            {
                isSuccess = true,
                health = saveData.Health,
                posX = saveData.PosX,
                posY = saveData.PosY,
                posZ = saveData.PosZ
            });
        }
    }
}