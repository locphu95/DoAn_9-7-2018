using System;
using Microsoft.EntityFrameworkCore;

namespace NguyenPhuLoc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public AppDbContext() { }

        public DbSet<CBNV> CBNV { get; set; }
        public DbSet<ChiTietDangKy> ChiTietDangKy { get; set; }
        public DbSet<ChiTietNhiemVu> ChiTietNhiemVu { get; set; }
        public DbSet<ChiTietQuanLy> ChiTietQuanLy { get; set; }
        public DbSet<ChiTietThucHien> ChiTietThucHien { get; set; }
        public DbSet<ChiTietToChuc> ChiTietToChuc { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<CongViec> CongViec { get; set; }
        public DbSet<DiemNghienCuuKhoaHoc> DiemNghienCuuKhoaHoc { get; set; }
        public DbSet<DonVi> DonVi { get; set; }
        public DbSet<HocKy> HocKy { get; set; }
        public DbSet<HoTro> HoTro { get; set; }
        public DbSet<LoaiGiangVien> LoaiGiangVien { get; set; }
        public DbSet<LoaiQuyetDinh> LoaiQuyetDinh { get; set; }
        public DbSet<MinhChung> MinhChung { get; set; }
        public DbSet<NamHoc> NamHoc { get; set; }
        public DbSet<NhiemVu> NhiemVu { get; set; }
        public DbSet<PhieuDangKy> PhieuDangKy { get; set; }
        public DbSet<QuyDinh> QuyDinh { get; set; }
        public DbSet<Quyen> Quyen { get; set; }
        public DbSet<QuyetDinh> QuyetDinh { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Define composite key.
            builder.Entity<ChiTietDangKy>()
                .HasKey(x => new { x.MaCongViec, x.MaPhieuDangKy });
            builder.Entity<ChiTietNhiemVu>()
                .HasKey(x => new { x.MaLoaiGiangVien, x.MaNhiemVu, x.MaNamHoc });
            builder.Entity<ChiTietQuanLy>()
                .HasKey(x => new { x.NgayQuyetDinh, x.MaCBNV, x.MaDonVi });
            builder.Entity<ChiTietThucHien>()
                .HasKey(x => new { x.MaCongViec, x.MaHoTro, x.MaPhieuDangKy });
            builder.Entity<ChiTietToChuc>()
                .HasKey(x => new { x.MaCongViec, x.MaDonVi });
            builder.Entity<DiemNghienCuuKhoaHoc>()
                .HasKey(x => new { x.MaCongViec, x.SoQuyDinh });
        }
    }
}
