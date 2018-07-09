using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class ChiTietThucHien
    {
     
        [ForeignKey("HoTro")]
        public string MaHoTro { get; set; } 
        public HoTro HoTro {get;set;}
        [ForeignKey("PhieuDangKy")]
        public string MaPhieuDangKy { get; set; }
        public PhieuDangKy PhieuDangKy {get;set;}
        [ForeignKey("CongViec")]
        public string MaCongViec { get; set; }
        public CongViec CongViec{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayXinHoTro { get; set; } 
        public int MucDoHoanThanh {get ; set;}
    
        public bool TrangThai {get;set;}
    }
}
