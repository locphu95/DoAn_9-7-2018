using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ThongkeController : Controller
    {
        private AppDbContext _db;
        public ThongkeController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                var model = (from cb in _db.CBNV
                             join l in _db.PhieuDangKy
                             on cb.MaCBNV equals l.MaCBNV
                             join ct in _db.ChiTietDangKy
                             on l.MaPhieuDangKy equals ct.MaPhieuDangKy
                             join cv in _db.CongViec
                             on ct.MaCongViec equals cv.MaCongViec
                             where cb.MaCBNV == id
                             select new
                             {
                                 l.MaPhieuDangKy,
                                 l.NgayDangKy,
                                 cv.TenCongViec
                             });

                // var model = _db.CBNV.ToList();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("Khoa/{id}")]
        public IActionResult Getkhoacv(string id)
        {
            try
            {
                var model = (from dv in _db.DonVi
                             join ctql in _db.ChiTietQuanLy
                             on dv.MaDonVi equals ctql.MaDonVi
                             join cb in _db.CBNV
                             on ctql.MaCBNV equals cb.MaCBNV
                             join pdk in _db.PhieuDangKy
                             on cb.MaCBNV equals pdk.MaCBNV
                             join ctdk in _db.ChiTietDangKy
                             on pdk.MaPhieuDangKy equals ctdk.MaPhieuDangKy
                             join cv in _db.CongViec
                             on ctdk.MaCongViec equals cv.MaCongViec
                             where dv.MaDonVi == id
                             select new
                             {
                                 cb.MaCBNV,
                                 cv.TenCongViec,
                                 cb.HoCBNV,
                                 cb.TenCBNV,
                                 pdk.MaPhieuDangKy,
                                 dv.TenDonVi
                             });
                var results = (from ssi in model
                                   // here I choose each field I want to group by
                               group ssi by new { ssi.MaCBNV, ssi.TenCBNV, ssi.HoCBNV } into g
                               select new { g.Key.MaCBNV, g.Key.TenCBNV, g.Key.HoCBNV, soluong = g.Count() }
   ).ToList();
                // var model = _db.CBNV.ToList();
                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("Allkhoa")]
        public IActionResult Getkhoa()
        {
            var tongcv = from ctdk in _db.ChiTietDangKy 
            group ctdk by new { ctdk.MaPhieuDangKy } into g 
             select new { g.Key.MaPhieuDangKy,soluong = g.Count()};
            var tongpdk = from pdk in _db.PhieuDangKy 
                          join o in tongcv on pdk.MaPhieuDangKy equals o.MaPhieuDangKy 
                          group o by new { pdk.MaCBNV } into e
                          select new {e.Key.MaCBNV, tong = e.Sum(d => d.soluong)} ;
            var results = from a in tongpdk 
                          join ql in _db.ChiTietQuanLy on a.MaCBNV equals ql.MaCBNV
                          join dv in _db.DonVi on ql.MaDonVi equals dv.MaDonVi
                          select new {
                            a,ql,dv
                          };
            return Ok(results);
        }

    }
}