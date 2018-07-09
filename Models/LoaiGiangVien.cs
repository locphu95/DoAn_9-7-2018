using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class LoaiGiangVien
    {
        [Key]
        public string MaLoaiGiangVien { get; set; } 
        public string TenLoaiGiangVien { get; set;}
        public string BaoHiem { get; set; }
        public bool TrangThai {get;set;}  
    }
}