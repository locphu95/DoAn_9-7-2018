using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class CongViec
    {
        [Key]
        public string MaCongViec { get; set; } 
        [ForeignKey("NhiemVu")]
        public string MaNhiemVu { get; set;}
        public NhiemVu NhiemVu {get;set;}
        public string TenCongViec { get; set; } 
        public string CapCongViec { get; set; }
        public string MoTaCongViec { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayBatDauDuKien { get; set; } 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayKetThucDuKien { get; set; }
        public float SoTietChuan { get; set; }
         public int SoLuongDangKy { get; set; }
        public int SoLuongConLai { get; set; } 
        
        public bool TrangThai {get;set;}
    }
}