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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaveDataId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public float Health { get; set; }
        public float MaxHealth { get; set; }              // NEW
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }

        public int? LastCheckpointID { get; set; }        // NEW
        public string? LastCheckpointScene { get; set; }  // NEW

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // NEW

        public User? User { get; set; }
    }
}
