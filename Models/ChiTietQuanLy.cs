using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NguyenPhuLoc.Models
{
    public class ChiTietQuanLy
    {
        [Key]
        public DateTime NgayQuyetDinh { get; set; } 
        [ForeignKey("CBNV")]
        public string MaCBNV{get;set;}
        public CBNV CBNV { get; set; }
        [ForeignKey("DonVi")]
        public string MaDonVi { get; set; }
        public DonVi DonVi {get;set;}
        [ForeignKey("ChucVu")]
        public string MaChucVu { get; set; }
        public ChucVu ChucVu{get;set;}
        public string ThoiHan { get; set; }
        public bool TrangThai {get;set;}
       
    }
}
