using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_API.DTO
{
    public class LoginResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Notification { get; set; }
        public object Data { get; set; }
    }
}