using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenPhuLoc.Models
{
    public class ChiTietNhiemVu
    {
        [ForeignKey("LoaiGiangVien")]
        public string MaLoaiGiangVien { get; set; }
        public LoaiGiangVien LoaiGiangVien{get;set;}
        [ForeignKey("NhiemVu")]
        public string MaNhiemVu {get ;set;}
        public NhiemVu NhiemVu { get; set; }
        [ForeignKey("NamHoc")]
        public string MaNamHoc { get; set; }
        public NamHoc NamHoc {get;set;}
        public int SoTietQuyDinh { get; set; } 
        public bool TrangThai {get;set;}
    }
}
