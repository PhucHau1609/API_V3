using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_API.Models
{
    public class User
    {
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    }
}