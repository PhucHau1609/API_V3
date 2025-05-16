using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_API.Models
{
    public class SaveData
    {
        public int SaveDataId { get; set; }
        public int UserId { get; set; }
        public float Health { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
    }
}