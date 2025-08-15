using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DATN_API.Data;
using DATN_API.DTO;
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

        // Upsert save
        [HttpPost("SaveGame")]
        public async Task<IActionResult> SaveGame([FromBody] SaveGameDTO model)
        {
            // (Optional) kiểm tra user tồn tại
            var userExists = await _context.Users.AnyAsync(u => u.UserId == model.UserId);
            if (!userExists)
                return BadRequest(new { isSuccess = false, message = "User không tồn tại." });

            var existingData = await _context.SaveDatas
                .FirstOrDefaultAsync(s => s.UserId == model.UserId);

            if (existingData != null)
            {
                existingData.PosX = model.PosX;
                existingData.PosY = model.PosY;
                existingData.PosZ = model.PosZ;
                existingData.Health = model.Health;
                existingData.MaxHealth = model.MaxHealth;
                existingData.LastCheckpointID = model.LastCheckpointID;
                existingData.LastCheckpointScene = model.LastCheckpointScene;
                existingData.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                _context.SaveDatas.Add(new SaveData
                {
                    UserId = model.UserId,
                    PosX = model.PosX,
                    PosY = model.PosY,
                    PosZ = model.PosZ,
                    Health = model.Health,
                    MaxHealth = model.MaxHealth,
                    LastCheckpointID = model.LastCheckpointID,
                    LastCheckpointScene = model.LastCheckpointScene,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { isSuccess = true, message = "Game saved successfully." });
        }

        // Load save
        [HttpGet("LoadGame/{userId:int}")]
        public async Task<IActionResult> LoadGame(int userId)
        {
            var saveData = await _context.SaveDatas.FirstOrDefaultAsync(s => s.UserId == userId);

            if (saveData == null)
                return NotFound(new { isSuccess = false, message = "No save data found." });

            return Ok(new
            {
                isSuccess = true,
                health = saveData.Health,
                maxHealth = saveData.MaxHealth,
                posX = saveData.PosX,
                posY = saveData.PosY,
                posZ = saveData.PosZ,
                lastCheckpointID = saveData.LastCheckpointID,
                lastCheckpointScene = saveData.LastCheckpointScene,
                updatedAt = saveData.UpdatedAt
            });
        }
    }
}
