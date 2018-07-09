using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CongviecController : Controller
    {
        private AppDbContext _db;
        public CongviecController(AppDbContext db)
        {
            _db = db;
        }
         public IActionResult Get()
        {
            var model =from a in _db.CongViec where  a.TrangThai==true && a.SoLuongConLai > 0 select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.CongViec.Find(id);
            return Ok(model);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(string id)
        {
            try
            {
                var model = from cv in _db.CongViec 
                             join nv in _db.NhiemVu on cv.MaNhiemVu equals nv.MaNhiemVu
                             join ctth in _db.ChiTietToChuc on cv.MaCongViec equals ctth.MaCongViec
                             join dv in _db.DonVi on ctth.MaDonVi equals dv.MaDonVi
                             where cv.MaCongViec==id 
                             select new
                             {
                          ctth.DiaDiemToChuc,  cv.CapCongViec,cv.MaCongViec,cv.TenCongViec,cv.MaNhiemVu,cv.NhiemVu.TenNhiemVu,ctth.DonVi.TenDonVi,cv.NgayBatDauDuKien,cv.NgayKetThucDuKien,cv.MoTaCongViec,cv.SoTietChuan,cv.SoLuongConLai,cv.SoLuongDangKy

                             };
                // var kq = from a in model group a by new{ a.MaNamHoc,a.NgayBatDauNamHoc,a.NgayKetThucNamHoc,a.MoTaNamHoc,a.MaHocKy} into g select new { g.Key.MaNamHoc,g.Key.NgayBatDauNamHoc,g.Key.NgayKetThucNamHoc,g.Key.MoTaNamHoc,g.Key.MaHocKy};
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] CongViec cb)
        {
          cb.TrangThai=true;
          try
          {
            CongViec tour=new CongViec(){
                MaCongViec=cb.MaCongViec,
                TenCongViec=cb.TenCongViec,
                MaNhiemVu= cb.MaNhiemVu,
                CapCongViec=cb.CapCongViec,
                MoTaCongViec = cb.MoTaCongViec,
                NgayBatDauDuKien = cb.NgayBatDauDuKien,
                NgayKetThucDuKien = cb.NgayKetThucDuKien,
                SoTietChuan = cb.SoTietChuan,
                SoLuongConLai = cb.SoLuongConLai,
                SoLuongDangKy = cb.SoLuongDangKy,
                TrangThai=cb.TrangThai
            };
            _db.CongViec.Add(tour);
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }
        [HttpGet("Delete/{id}")]
         public IActionResult Post3(string id)
        {
          try{
            CongViec del =_db.CongViec.FirstOrDefault(x=>x.MaCongViec==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] CongViec cb,string id)
        {
          try{
            CongViec edit =_db.CongViec.FirstOrDefault(x=>x.MaCongViec==id);
                edit.TenCongViec=cb.TenCongViec;
                edit.MaNhiemVu= cb.MaNhiemVu;
                edit.CapCongViec=cb.CapCongViec;
                edit.MoTaCongViec = cb.MoTaCongViec;
                edit.NgayBatDauDuKien = cb.NgayBatDauDuKien;
                edit.NgayKetThucDuKien = cb.NgayKetThucDuKien;
                edit.SoTietChuan = cb.SoTietChuan;
                edit.SoLuongConLai = cb.SoLuongConLai;
                edit.SoLuongDangKy = cb.SoLuongDangKy;
            _db.SaveChanges();
            return Ok("Cập nhật thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
    }    
}
