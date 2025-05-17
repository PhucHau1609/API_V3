using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DATN_API.Data;
using DATN_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DATN_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.Email == request.Email && x.Password == request.Password);

            if (user == null)
            {
                return BadRequest(new LoginResponseModel
                {
                    IsSuccess = false,
                    Notification = "Email hoặc mật khẩu không chính xác"
                });
            }

            return Ok(new LoginResponseModel
            {
                IsSuccess = true,
                Notification = "Đăng nhập thành công",
                Data = new
                {
                    email = user.Email,
                    userName = user.Username,
                }
            });
        }
    }
}