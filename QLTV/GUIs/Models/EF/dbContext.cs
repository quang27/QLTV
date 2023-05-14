using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GUIs.Models.EF
{
    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<LOP> LOP { get; set; }
        public virtual DbSet<MUONTRA> MUONTRA { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBAN { get; set; }
        public virtual DbSet<PHANLOAISACH> PHANLOAISACH { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<SACHCHITIET> SACHCHITIET { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIEN { get; set; }
        public virtual DbSet<TACGIA> TACGIA { get; set; }
        public virtual DbSet<TACGIASACH> TACGIASACH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOP>()
                .Property(e => e.TenLop)
                .IsFixedLength();

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Pass)
                .IsFixedLength();

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.MUONTRA)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.NVMuonId);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.MUONTRA1)
                .WithOptional(e => e.NHANVIEN1)
                .HasForeignKey(e => e.NVTraId);

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.SACH)
                .WithOptional(e => e.NHAXUATBAN)
                .HasForeignKey(e => e.NXBId);

            modelBuilder.Entity<PHANLOAISACH>()
                .HasMany(e => e.SACH)
                .WithOptional(e => e.PHANLOAISACH)
                .HasForeignKey(e => e.PhanLoaiId);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Noi_dung)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.SACHCHITIET)
                .WithRequired(e => e.SACH)
                .HasForeignKey(e => e.MaSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.TACGIASACH)
                .WithOptional(e => e.SACH)
                .HasForeignKey(e => e.MaSach);

            modelBuilder.Entity<SACHCHITIET>()
                .HasMany(e => e.MUONTRA)
                .WithOptional(e => e.SACHCHITIET)
                .HasForeignKey(e => e.SachCTId);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.Pass)
                .IsFixedLength();

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.MUONTRA)
                .WithOptional(e => e.SINHVIEN)
                .HasForeignKey(e => e.SVId);
        }
    }
}
