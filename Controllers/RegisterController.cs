using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DATN_API.Data;
using DATN_API.Models;
using DATN_API.DTO;


namespace DATN_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return Ok(new
                {
                    isSuccess = false,
                    notification = string.Join(" | ", errors),
                    data = (object)null
                });
            }
            // Kiểm tra xem email đã tồn tại chưa
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (existingUser != null)
            {
                 return Ok(new
                {
                    isSuccess = false,
                    notification = "Email đã được sử dụng.",
                    data = (object)null
                });
            }

            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password // ⚠️ Trong thực tế nên mã hóa mật khẩu
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new
            {
                isSuccess = true,
                notification = "Đăng ký thành công!",
                data = new
                {
                    Email = newUser.Email,
                    Name = newUser.Username
                }
            });
        }
    }
}