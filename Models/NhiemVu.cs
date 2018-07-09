using System;
using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class NhiemVu
    {
        [Key]
        public string MaNhiemVu { get; set; } 
        public string TenNhiemVu { get; set;}
        public bool TrangThai {get;set;}

    }
}