using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NhomZuiZeDoAn.Models
{
    public partial class DongHoContext : DbContext
    {
        public DongHoContext()
            : base("name=DongHoContext")
        {
        }

        public virtual DbSet<DongHo> DongHoes { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hang>()
                .HasMany(e => e.DongHoes)
                .WithOptional(e => e.Hangss)
                .HasForeignKey(e => e.Hang);
        }
    }
}
