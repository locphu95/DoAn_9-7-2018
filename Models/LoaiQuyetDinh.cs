using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class LoaiQuyetDinh
    {
        [Key]
        public string MaLoaiQuyetDinh { get; set; } 
        public string TenLoaiQuyetDinh { get; set;}     
        public bool TrangThai {get;set;}
    }
}