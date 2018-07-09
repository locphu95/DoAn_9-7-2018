using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenPhuLoc.Models
{
    public class HocKy
    {
        [Key]
        public string MaHocKy { get; set; }
        [ForeignKey("NamHoc")]
        public string MaNamHoc { get; set; }
        public NamHoc NamHoc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayBatDauHocKy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayKetThucHocKy { get; set; }
        public bool TrangThai {get;set;}
    }
}