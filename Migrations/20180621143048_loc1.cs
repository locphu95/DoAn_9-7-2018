using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NguyenPhuLoc.Migrations
{
    public partial class loc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(nullable: false),
                    TenChucVu = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "DonVi",
                columns: table => new
                {
                    MaDonVi = table.Column<string>(nullable: false),
                    TenDonVi = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVi", x => x.MaDonVi);
                });

            migrationBuilder.CreateTable(
                name: "HoTro",
                columns: table => new
                {
                    MaHoTro = table.Column<string>(nullable: false),
                    NguonHoTro = table.Column<string>(nullable: true),
                    LoaiHoTro = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    DonViTinh = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoTro", x => x.MaHoTro);
                });

            migrationBuilder.CreateTable(
                name: "LoaiGiangVien",
                columns: table => new
                {
                    MaLoaiGiangVien = table.Column<string>(nullable: false),
                    TenLoaiGiangVien = table.Column<string>(nullable: true),
                    BaoHiem = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGiangVien", x => x.MaLoaiGiangVien);
                });

            migrationBuilder.CreateTable(
                name: "LoaiQuyetDinh",
                columns: table => new
                {
                    MaLoaiQuyetDinh = table.Column<string>(nullable: false),
                    TenLoaiQuyetDinh = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiQuyetDinh", x => x.MaLoaiQuyetDinh);
                });

            migrationBuilder.CreateTable(
                name: "NamHoc",
                columns: table => new
                {
                    MaNamHoc = table.Column<string>(nullable: false),
                    NgayBatDauNamHoc = table.Column<DateTime>(nullable: false),
                    NgayKetThucNamHoc = table.Column<DateTime>(nullable: false),
                    MoTaNamHoc = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamHoc", x => x.MaNamHoc);
                });

            migrationBuilder.CreateTable(
                name: "NhiemVu",
                columns: table => new
                {
                    MaNhiemVu = table.Column<string>(nullable: false),
                    TenNhiemVu = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVu", x => x.MaNhiemVu);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    MaQuyen = table.Column<string>(nullable: false),
                    TenQuyen = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "HocKy",
                columns: table => new
                {
                    MaHocKy = table.Column<string>(nullable: false),
                    MaNamHoc = table.Column<string>(nullable: true),
                    NgayBatDauHocKy = table.Column<DateTime>(nullable: false),
                    NgayKetThucHocKy = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKy", x => x.MaHocKy);
                    table.ForeignKey(
                        name: "FK_HocKy_NamHoc_MaNamHoc",
                        column: x => x.MaNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "MaNamHoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuyDinh",
                columns: table => new
                {
                    SoQuyDinh = table.Column<string>(nullable: false),
                    NgayBanHanh = table.Column<DateTime>(nullable: false),
                    NoiDungQuyDinh = table.Column<string>(nullable: true),
                    MaNamHoc = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyDinh", x => x.SoQuyDinh);
                    table.ForeignKey(
                        name: "FK_QuyDinh_NamHoc_MaNamHoc",
                        column: x => x.MaNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "MaNamHoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhiemVu",
                columns: table => new
                {
                    MaLoaiGiangVien = table.Column<string>(nullable: false),
                    MaNhiemVu = table.Column<string>(nullable: false),
                    MaNamHoc = table.Column<string>(nullable: false),
                    SoTietQuyDinh = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhiemVu", x => new { x.MaLoaiGiangVien, x.MaNhiemVu, x.MaNamHoc });
                    table.ForeignKey(
                        name: "FK_ChiTietNhiemVu_LoaiGiangVien_MaLoaiGiangVien",
                        column: x => x.MaLoaiGiangVien,
                        principalTable: "LoaiGiangVien",
                        principalColumn: "MaLoaiGiangVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhiemVu_NamHoc_MaNamHoc",
                        column: x => x.MaNamHoc,
                        principalTable: "NamHoc",
                        principalColumn: "MaNamHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhiemVu_NhiemVu_MaNhiemVu",
                        column: x => x.MaNhiemVu,
                        principalTable: "NhiemVu",
                        principalColumn: "MaNhiemVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    MaCongViec = table.Column<string>(nullable: false),
                    MaNhiemVu = table.Column<string>(nullable: true),
                    TenCongViec = table.Column<string>(nullable: true),
                    CapCongViec = table.Column<string>(nullable: true),
                    MoTaCongViec = table.Column<string>(nullable: true),
                    NgayBatDauDuKien = table.Column<DateTime>(nullable: false),
                    NgayKetThucDuKien = table.Column<DateTime>(nullable: false),
                    SoTietChuan = table.Column<float>(nullable: false),
                    SoLuongDangKy = table.Column<int>(nullable: false),
                    SoLuongConLai = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongViec", x => x.MaCongViec);
                    table.ForeignKey(
                        name: "FK_CongViec_NhiemVu_MaNhiemVu",
                        column: x => x.MaNhiemVu,
                        principalTable: "NhiemVu",
                        principalColumn: "MaNhiemVu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CBNV",
                columns: table => new
                {
                    MaCBNV = table.Column<string>(nullable: false),
                    MaQuyen = table.Column<string>(nullable: true),
                    MaLoaiGiangVien = table.Column<string>(nullable: true),
                    HoCBNV = table.Column<string>(nullable: true),
                    TenCBNV = table.Column<string>(nullable: true),
                    NTNS = table.Column<DateTime>(nullable: true),
                    Phai = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    HocVi = table.Column<string>(nullable: true),
                    TenDangNhap = table.Column<string>(nullable: true),
                    MatKhau = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CBNV", x => x.MaCBNV);
                    table.ForeignKey(
                        name: "FK_CBNV_LoaiGiangVien_MaLoaiGiangVien",
                        column: x => x.MaLoaiGiangVien,
                        principalTable: "LoaiGiangVien",
                        principalColumn: "MaLoaiGiangVien",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CBNV_Quyen_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "Quyen",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietToChuc",
                columns: table => new
                {
                    MaDonVi = table.Column<string>(nullable: false),
                    MaCongViec = table.Column<string>(nullable: false),
                    DiaDiemToChuc = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietToChuc", x => new { x.MaCongViec, x.MaDonVi });
                    table.ForeignKey(
                        name: "FK_ChiTietToChuc_CongViec_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "CongViec",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietToChuc_DonVi_MaDonVi",
                        column: x => x.MaDonVi,
                        principalTable: "DonVi",
                        principalColumn: "MaDonVi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiemNghienCuuKhoaHoc",
                columns: table => new
                {
                    SoQuyDinh = table.Column<string>(nullable: false),
                    MaCongViec = table.Column<string>(nullable: false),
                    Diem = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemNghienCuuKhoaHoc", x => new { x.MaCongViec, x.SoQuyDinh });
                    table.ForeignKey(
                        name: "FK_DiemNghienCuuKhoaHoc_CongViec_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "CongViec",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiemNghienCuuKhoaHoc_QuyDinh_SoQuyDinh",
                        column: x => x.SoQuyDinh,
                        principalTable: "QuyDinh",
                        principalColumn: "SoQuyDinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietQuanLy",
                columns: table => new
                {
                    NgayQuyetDinh = table.Column<DateTime>(nullable: false),
                    MaCBNV = table.Column<string>(nullable: false),
                    MaDonVi = table.Column<string>(nullable: false),
                    MaChucVu = table.Column<string>(nullable: true),
                    ThoiHan = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietQuanLy", x => new { x.NgayQuyetDinh, x.MaCBNV, x.MaDonVi });
                    table.UniqueConstraint("AK_ChiTietQuanLy_NgayQuyetDinh", x => x.NgayQuyetDinh);
                    table.ForeignKey(
                        name: "FK_ChiTietQuanLy_CBNV_MaCBNV",
                        column: x => x.MaCBNV,
                        principalTable: "CBNV",
                        principalColumn: "MaCBNV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietQuanLy_ChucVu_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietQuanLy_DonVi_MaDonVi",
                        column: x => x.MaDonVi,
                        principalTable: "DonVi",
                        principalColumn: "MaDonVi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuDangKy",
                columns: table => new
                {
                    MaPhieuDangKy = table.Column<string>(nullable: false),
                    MaCBNV = table.Column<string>(nullable: true),
                    MaHocKy = table.Column<string>(nullable: true),
                    NgayDangKy = table.Column<DateTime>(nullable: false),
                    NguoiDangKy = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDangKy", x => x.MaPhieuDangKy);
                    table.ForeignKey(
                        name: "FK_PhieuDangKy_CBNV_MaCBNV",
                        column: x => x.MaCBNV,
                        principalTable: "CBNV",
                        principalColumn: "MaCBNV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuDangKy_HocKy_MaHocKy",
                        column: x => x.MaHocKy,
                        principalTable: "HocKy",
                        principalColumn: "MaHocKy",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinh",
                columns: table => new
                {
                    SoQuyetDinh = table.Column<string>(nullable: false),
                    MaCBNV = table.Column<string>(nullable: true),
                    MaLoaiQuyetDinh = table.Column<string>(nullable: true),
                    NgayBanHanh = table.Column<DateTime>(nullable: false),
                    NoiDungQuyetDinh = table.Column<string>(nullable: true),
                    HinhThuc = table.Column<string>(nullable: true),
                    ThoiHan = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinh", x => x.SoQuyetDinh);
                    table.ForeignKey(
                        name: "FK_QuyetDinh_CBNV_MaCBNV",
                        column: x => x.MaCBNV,
                        principalTable: "CBNV",
                        principalColumn: "MaCBNV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyetDinh_LoaiQuyetDinh_MaLoaiQuyetDinh",
                        column: x => x.MaLoaiQuyetDinh,
                        principalTable: "LoaiQuyetDinh",
                        principalColumn: "MaLoaiQuyetDinh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDangKy",
                columns: table => new
                {
                    MaPhieuDangKy = table.Column<string>(nullable: false),
                    MaCongViec = table.Column<string>(nullable: false),
                    NgayBatDauThucTe = table.Column<string>(nullable: true),
                    NgayKetThucThucTe = table.Column<string>(nullable: true),
                    NhanXetDonVi = table.Column<string>(nullable: true),
                    DanhGiaDonVi = table.Column<string>(nullable: true),
                    DiemDonVi = table.Column<string>(nullable: true),
                    NhanXetTruong = table.Column<string>(nullable: true),
                    DanhGiaTruong = table.Column<string>(nullable: true),
                    DiemTruong = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDangKy", x => new { x.MaCongViec, x.MaPhieuDangKy });
                    table.ForeignKey(
                        name: "FK_ChiTietDangKy_CongViec_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "CongViec",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDangKy_PhieuDangKy_MaPhieuDangKy",
                        column: x => x.MaPhieuDangKy,
                        principalTable: "PhieuDangKy",
                        principalColumn: "MaPhieuDangKy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThucHien",
                columns: table => new
                {
                    MaHoTro = table.Column<string>(nullable: false),
                    MaPhieuDangKy = table.Column<string>(nullable: false),
                    MaCongViec = table.Column<string>(nullable: false),
                    NgayXinHoTro = table.Column<DateTime>(nullable: false),
                    MucDoHoanThanh = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietThucHien", x => new { x.MaCongViec, x.MaHoTro, x.MaPhieuDangKy });
                    table.ForeignKey(
                        name: "FK_ChiTietThucHien_CongViec_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "CongViec",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietThucHien_HoTro_MaHoTro",
                        column: x => x.MaHoTro,
                        principalTable: "HoTro",
                        principalColumn: "MaHoTro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietThucHien_PhieuDangKy_MaPhieuDangKy",
                        column: x => x.MaPhieuDangKy,
                        principalTable: "PhieuDangKy",
                        principalColumn: "MaPhieuDangKy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinhChung",
                columns: table => new
                {
                    MaMinhChung = table.Column<string>(nullable: false),
                    MaPhieuDangKy = table.Column<string>(nullable: true),
                    MaCongViec = table.Column<string>(nullable: true),
                    TenMinhChung = table.Column<string>(nullable: true),
                    NgayDangMinhChung = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinhChung", x => x.MaMinhChung);
                    table.ForeignKey(
                        name: "FK_MinhChung_CongViec_MaCongViec",
                        column: x => x.MaCongViec,
                        principalTable: "CongViec",
                        principalColumn: "MaCongViec",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MinhChung_PhieuDangKy_MaPhieuDangKy",
                        column: x => x.MaPhieuDangKy,
                        principalTable: "PhieuDangKy",
                        principalColumn: "MaPhieuDangKy",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CBNV_MaLoaiGiangVien",
                table: "CBNV",
                column: "MaLoaiGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_CBNV_MaQuyen",
                table: "CBNV",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangKy_MaPhieuDangKy",
                table: "ChiTietDangKy",
                column: "MaPhieuDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhiemVu_MaNamHoc",
                table: "ChiTietNhiemVu",
                column: "MaNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhiemVu_MaNhiemVu",
                table: "ChiTietNhiemVu",
                column: "MaNhiemVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuanLy_MaCBNV",
                table: "ChiTietQuanLy",
                column: "MaCBNV");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuanLy_MaChucVu",
                table: "ChiTietQuanLy",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuanLy_MaDonVi",
                table: "ChiTietQuanLy",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThucHien_MaHoTro",
                table: "ChiTietThucHien",
                column: "MaHoTro");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThucHien_MaPhieuDangKy",
                table: "ChiTietThucHien",
                column: "MaPhieuDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietToChuc_MaDonVi",
                table: "ChiTietToChuc",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_MaNhiemVu",
                table: "CongViec",
                column: "MaNhiemVu");

            migrationBuilder.CreateIndex(
                name: "IX_DiemNghienCuuKhoaHoc_SoQuyDinh",
                table: "DiemNghienCuuKhoaHoc",
                column: "SoQuyDinh");

            migrationBuilder.CreateIndex(
                name: "IX_HocKy_MaNamHoc",
                table: "HocKy",
                column: "MaNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_MinhChung_MaCongViec",
                table: "MinhChung",
                column: "MaCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_MinhChung_MaPhieuDangKy",
                table: "MinhChung",
                column: "MaPhieuDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKy_MaCBNV",
                table: "PhieuDangKy",
                column: "MaCBNV");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKy_MaHocKy",
                table: "PhieuDangKy",
                column: "MaHocKy");

            migrationBuilder.CreateIndex(
                name: "IX_QuyDinh_MaNamHoc",
                table: "QuyDinh",
                column: "MaNamHoc");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_MaCBNV",
                table: "QuyetDinh",
                column: "MaCBNV");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinh_MaLoaiQuyetDinh",
                table: "QuyetDinh",
                column: "MaLoaiQuyetDinh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDangKy");

            migrationBuilder.DropTable(
                name: "ChiTietNhiemVu");

            migrationBuilder.DropTable(
                name: "ChiTietQuanLy");

            migrationBuilder.DropTable(
                name: "ChiTietThucHien");

            migrationBuilder.DropTable(
                name: "ChiTietToChuc");

            migrationBuilder.DropTable(
                name: "DiemNghienCuuKhoaHoc");

            migrationBuilder.DropTable(
                name: "MinhChung");

            migrationBuilder.DropTable(
                name: "QuyetDinh");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "HoTro");

            migrationBuilder.DropTable(
                name: "DonVi");

            migrationBuilder.DropTable(
                name: "QuyDinh");

            migrationBuilder.DropTable(
                name: "CongViec");

            migrationBuilder.DropTable(
                name: "PhieuDangKy");

            migrationBuilder.DropTable(
                name: "LoaiQuyetDinh");

            migrationBuilder.DropTable(
                name: "NhiemVu");

            migrationBuilder.DropTable(
                name: "CBNV");

            migrationBuilder.DropTable(
                name: "HocKy");

            migrationBuilder.DropTable(
                name: "LoaiGiangVien");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "NamHoc");
        }
    }
}
