using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenPhuLoc.Models
{
    public class ChiTietDangKy
    {
        [ForeignKey("PhieuDangKy")] 
        public string MaPhieuDangKy { get; set; } 
        public PhieuDangKy PhieuDangKy { get; set; }
        [ForeignKey("CongViec")] 
        public string MaCongViec { get; set; }
        public CongViec CongViec {get;set;}
        public string NgayBatDauThucTe { get; set; }
        public string NgayKetThucThucTe { get; set; } 
        public string NhanXetDonVi { get; set; }
        public string DanhGiaDonVi { get; set; }
         public string DiemDonVi { get; set; }
        public string NhanXetTruong { get; set; } 
        public string DanhGiaTruong { get; set; }
        public string DiemTruong { get; set; }
        public bool TrangThai {get;set;}
    }
}
