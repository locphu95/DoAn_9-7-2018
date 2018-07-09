using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class PhieuDangKy
    {
        [Key]
        public string MaPhieuDangKy { get; set; } 
        [ForeignKey("CBNV")]
        public string MaCBNV { get; set;}
        public CBNV CBNV {get;set;}
        [ForeignKey("HocKy")]
        public string MaHocKy { get; set; }
        public HocKy HocKy {get;set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayDangKy { get; set;}
        public string NguoiDangKy {get;set;}
        public bool TrangThai {get;set;}
    }
}