using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class QuyetDinh
    {
        [Key]
        public string SoQuyetDinh { get; set; } 
        [ForeignKey("CBNV")]
        public string MaCBNV { get; set; } 
        public CBNV CBNV {get;set;}
        [ForeignKey("LoaiQuyetDinh")]
        public string MaLoaiQuyetDinh { get; set; }
        public LoaiQuyetDinh LoaiQuyetDinh {get;set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayBanHanh { get; set; } 
        public string NoiDungQuyetDinh { get; set; } 
        public string HinhThuc { get; set; } 
        public int ThoiHan { get; set; }
        public bool TrangThai {get;set;}

        
    }
}