using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Nếu muốn lấy dữ liệu save tương ứng
        public ICollection<SaveData>? SaveData { get; set; }
    }
}