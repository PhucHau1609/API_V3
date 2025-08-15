using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DATN_API.Models;

namespace DATN_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 0 references
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SaveData> SaveDatas { get; set; }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mỗi user chỉ có 1 save row
            modelBuilder.Entity<SaveData>()
                .HasIndex(s => s.UserId)
                .IsUnique();
        }
    }
}