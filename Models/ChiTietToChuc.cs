using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NguyenPhuLoc.Models
{
    public class ChiTietToChuc
    {
        [ForeignKey("DonVi")]
        public string MaDonVi { get; set; }
        public DonVi DonVi {get;set;}
        [ForeignKey("CongViec")]
        public string MaCongViec { get; set; }
        public CongViec CongViec{get;set;}
        public string DiaDiemToChuc { get; set; }
        public bool TrangThai {get;set;}
    
    }
}
