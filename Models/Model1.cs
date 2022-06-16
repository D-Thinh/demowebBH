using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WedBH.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Baohiem> Baohiems { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Phankhoixe> Phankhoixes { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baohiem>()
                .Property(e => e.MABH)
                .IsUnicode(false);

            modelBuilder.Entity<Baohiem>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Baohiem>()
                .Property(e => e.MAPK)
                .IsUnicode(false);

            modelBuilder.Entity<Baohiem>()
                .Property(e => e.BIENSO)
                .IsUnicode(false);

            modelBuilder.Entity<Baohiem>()
                .Property(e => e.SOKHUNG)
                .IsUnicode(false);

            modelBuilder.Entity<Baohiem>()
                .Property(e => e.SOMAY)
                .IsUnicode(false);

            modelBuilder.Entity<Baohiem>()
                .Property(e => e.PHIBH)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Phankhoixe>()
                .Property(e => e.MAPK)
                .IsUnicode(false);

            modelBuilder.Entity<Phankhoixe>()
                .HasMany(e => e.Baohiems)
                .WithRequired(e => e.Phankhoixe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Taikhoan>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<Taikhoan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SDT)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<WedBH.Models.YeucauBD> YeucauBDs { get; set; }
    }
}
