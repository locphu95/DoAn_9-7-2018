using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class QuyDinh
    {
        [Key]
        public string SoQuyDinh { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayBanHanh { get; set; } 
        public string NoiDungQuyDinh { get; set;}
        [ForeignKey("NamHoc")]
        public string MaNamHoc {get;set;}
        public NamHoc NamHoc {get; set;}
        public bool TrangThai {get;set;}
    }
}