using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenPhuLoc.Models
{
    public class DiemNghienCuuKhoaHoc
    {
        [ForeignKey("QuyDinh")]
        public string SoQuyDinh { get; set; } 
        public QuyDinh QuyDinh{get;set;}
        [ForeignKey("CongViec")]
        public string MaCongViec { get; set;}
        public CongViec CongViec {get; set;}
        public int Diem { get; set; } 
        public bool TrangThai {get;set;}
        
    }
}