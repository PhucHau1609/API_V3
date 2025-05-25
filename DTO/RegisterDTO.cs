using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DATN_API.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        [MaxLength(20, ErrorMessage = "Tên không vượt quá 20 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [MaxLength(20, ErrorMessage = "Email không vượt quá 15 ký tự")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 15 ký tự")]
        public string Password { get; set; }
    }
}