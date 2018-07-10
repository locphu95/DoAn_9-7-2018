using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PhieudangkyController : Controller
    {
        private AppDbContext _db;
        public PhieudangkyController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{manv}")]
        public IActionResult Get(string manv)
        {
            var model = _db.PhieuDangKy.Where(x => x.MaPhieuDangKy == manv).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = from a in _db.PhieuDangKy
                        join d in _db.CBNV on a.MaCBNV equals d.MaCBNV
                        where a.TrangThai == true
                        orderby a.MaPhieuDangKy

                        select new
                        {
                            a.MaPhieuDangKy,
                            a.MaHocKy,
                            a.NgayDangKy,
                            a.NguoiDangKy,
                            a.MaCBNV,
                            d.HoCBNV,
                            d.TenCBNV
                        };
            // var ef = (from e in model   group e by new { e.MaCBNV, e.TenCBNV, e.HoCBNV,e.TenCongViec } into g
            //                    select new { g.Key.MaCBNV, g.Key.TenCBNV, g.Key.HoCBNV, g.Key.TenCongViec,soluong = g.Count() }).ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                PhieuDangKy model = _db.PhieuDangKy.Find(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GETdetail(string id)
        {

            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] PhieuDangKy cb)
        {
            cb.TrangThai = true;
            try
            {
                PhieuDangKy tour = new PhieuDangKy()
                {
                    MaCBNV = cb.MaCBNV,
                    NgayDangKy = cb.NgayDangKy,
                    NguoiDangKy = cb.NguoiDangKy,
                    MaPhieuDangKy = cb.MaPhieuDangKy,
                    MaHocKy = cb.MaCBNV,
                    TrangThai = cb.TrangThai
                };
                _db.PhieuDangKy.Add(tour);
                _db.SaveChanges();
                return Ok("Them thanh cong");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Edit/{id}")]
        public IActionResult Post2([FromBody] PhieuDangKy cb, string id)
        {
            try
            {
                PhieuDangKy edit = _db.PhieuDangKy.FirstOrDefault(x => x.MaPhieuDangKy == id);
                edit.MaCBNV = cb.MaCBNV;
                edit.MaHocKy = cb.MaHocKy;
                edit.NgayDangKy = cb.NgayDangKy;
                edit.NguoiDangKy = cb.NguoiDangKy;
                _db.SaveChanges();
                return Ok("Them thanh cong");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("Delete/{id}")]
        public IActionResult Post3(string id)
        {
            try
            {
                PhieuDangKy del = _db.PhieuDangKy.FirstOrDefault(x => x.MaPhieuDangKy == id);
                del.TrangThai = false;
                _db.SaveChanges();
                return Ok("Xoa thanh cong");
            }
            catch
            {
                return BadRequest();
            }
        }



    }


}
