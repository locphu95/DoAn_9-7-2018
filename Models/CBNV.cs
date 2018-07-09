using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class CBNV
    {
        [Key]
        public string MaCBNV { get; set; }
        [ForeignKey("Quyen")]   
        public string MaQuyen { get; set; }
        public Quyen Quyen {get;set;}
        [ForeignKey("LoaiGiangVien")]
        public string MaLoaiGiangVien { get; set; } 
        public LoaiGiangVien LoaiGiangVien {get; set;}
        public string HoCBNV { get; set; } 
        public string TenCBNV { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? NTNS {get;set;}
        public string Phai { get; set; }
        public string DiaChi { get; set; }
        public string HocVi { get; set; } 
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public bool TrangThai {get;set;}
    }
}
