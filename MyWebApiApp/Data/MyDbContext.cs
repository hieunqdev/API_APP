﻿using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHanga { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);

                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired()
                                              .HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDh, e.MaHh });

                entity.HasOne(e => e.DonHang)
                      .WithMany(e => e.DonHangChiTiets)
                      .HasForeignKey(e => e.MaDh)
                      .HasConstraintName("FK_DonHangCt_DonHang");

                entity.HasOne(e => e.HangHoa)
                      .WithMany(e => e.DonHangChiTiets)
                      .HasForeignKey(e => e.MaHh)
                      .HasConstraintName("FK_DonHangCt_HangHoa");
            }); 

        }
    }
}
