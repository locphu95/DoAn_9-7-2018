using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QuyenController : Controller
    {
        private AppDbContext _db;
        public QuyenController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{ma}")]
        public IActionResult Get(string ma)
        {
            var model = _db.Quyen.Where(x => x.MaQuyen == ma).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = from a in _db.Quyen where a.TrangThai == true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                Quyen model = _db.Quyen.Find(id);
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
        [HttpGet("Delete/{id}")]
         public IActionResult Post3(string id)
        {
          try{
            Quyen del =_db.Quyen.FirstOrDefault(x=>x.MaQuyen==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost]
      public IActionResult Post([FromBody] Quyen qd)
        {
          qd.TrangThai=true;
          try
          {
            Quyen tour=new  Quyen(){
                MaQuyen=qd.MaQuyen,
                TenQuyen=qd.TenQuyen,
                TrangThai=qd.TrangThai
            };
            _db.Quyen.Add(tour);
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] Quyen cb,string id)
        {
          try{
            Quyen edit =_db.Quyen.FirstOrDefault(x=>x.MaQuyen==id);
              edit.TenQuyen=cb.TenQuyen;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }



    }


}
