using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DnckhController : Controller
    {
        private AppDbContext _db;
        public DnckhController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{manv}/{manh}")]
        public IActionResult Get(string manv, string manh)
        {
            var model = _db.DiemNghienCuuKhoaHoc.Where(x => x.SoQuyDinh == manv && x.MaCongViec == manh).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _db.DiemNghienCuuKhoaHoc.ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                DiemNghienCuuKhoaHoc model = _db.DiemNghienCuuKhoaHoc.Find(id);
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
