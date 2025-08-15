using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_API.DTO
{
    public class SaveGameDTO
    {
        public int UserId { get; set; }                 // Unity gửi kèm
        public float Health { get; set; }
        public float MaxHealth { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public int? LastCheckpointID { get; set; }
        public string? LastCheckpointScene { get; set; }
    }
}
