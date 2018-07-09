using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class ChucVu
    {
        [Key]
        public string MaChucVu { get; set; } 
        public string TenChucVu { get; set;}
        public bool TrangThai {get;set;}
        
    }
}
