using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WedBH.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<YeucauBD> YeucauBDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TRIGIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<YeucauBD>()
                .Property(e => e.MAYC)
                .IsUnicode(false);

            modelBuilder.Entity<YeucauBD>()
                .Property(e => e.TK)
                .IsUnicode(false);
        }
    }
}
