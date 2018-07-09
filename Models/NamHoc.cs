using System;
using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class NamHoc
    {
        [Key]
        public string MaNamHoc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayBatDauNamHoc { get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NgayKetThucNamHoc { get; set; }         
        public string MoTaNamHoc { get; set; }
        public bool TrangThai {get;set;}

    }
}