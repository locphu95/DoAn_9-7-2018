using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class MinhChung
    {
        [Key]
        public string MaMinhChung { get; set; } 
        [ForeignKey("PhieuDangKy")]
        public string MaPhieuDangKy { get; set;}
        public PhieuDangKy PhieuDangKy {get;set;}
        [ForeignKey("CongViec")]
        public string MaCongViec { get; set; }
        public CongViec CongViec {get ; set;}         
        public string TenMinhChung { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayDangMinhChung { get; set; }
        public bool TrangThai {get;set;}

    }
}