using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CtthController : Controller
    {
        private AppDbContext _db;
        public CtthController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{manv}/{manh}/{maht}")]
        public IActionResult Get(string manv, string manh, string maht)
        {
            var model = _db.ChiTietThucHien.Where(x => x.MaPhieuDangKy == manv && x.MaHoTro == manh && x.MaCongViec == maht).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _db.ChiTietThucHien.ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                ChiTietThucHien model = _db.ChiTietThucHien.Find(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(int id)
        {
            try
            {
                var model = (from cb in _db.CBNV
                             from l in _db.LoaiGiangVien
                             where cb.MaLoaiGiangVien == l.MaLoaiGiangVien
                             select new
                             {
                                 l.TenLoaiGiangVien,

                             }).ToList();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



    }


}
