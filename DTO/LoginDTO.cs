using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DATN_API.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [MaxLength(15, ErrorMessage = "Email không vượt quá 15 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 15 ký tự")]
        public string Password { get; set; }
    }
}