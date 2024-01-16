using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01.Entity
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<HocSinh> HocSinh { get; set; }
        public virtual DbSet<Lop> Lop { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V5E7153\\SQLEXPRESS;Database=EF_01;Trusted_Connection = True;TrustServerCertificate=True");
        }
    }
}
