using System;
using System.ComponentModel.DataAnnotations;


namespace NguyenPhuLoc.Models
{
    public class Quyen
    {
        [Key]
        public string MaQuyen { get; set; } 
        public string TenQuyen { get; set; }
        public bool TrangThai {get;set;}
        
    }
}