using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATN_API.Models
{
   public class SaveData
{
    public int SaveDataId { get; set; }
    public int UserId { get; set; }

    public double Health { get; set; }
    public double MaxHealth { get; set; }
    public double PosX { get; set; }
    public double PosY { get; set; }
    public double PosZ { get; set; }

    public int? LastCheckpointID { get; set; }
    public string? LastCheckpointScene { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public User? User { get; set; }
}

}
