using System.ComponentModel.DataAnnotations;

namespace NguyenPhuLoc.Models
{
    public class DonVi
    {
        [Key]
        public string MaDonVi { get; set; } 
        public string TenDonVi { get; set;}
        public string DienThoai { get; set; } 
        public bool TrangThai {get;set;}
        
    }
}