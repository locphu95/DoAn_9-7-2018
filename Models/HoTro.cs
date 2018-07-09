using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class HoTro
    {
        [Key]
        public string MaHoTro { get; set; } 
        public string NguonHoTro { get; set;}
        public string LoaiHoTro { get; set; } 
        public int SoLuong { get; set; } 
        public string DonViTinh { get; set; } 
        public bool TrangThai {get;set;}
    }
}