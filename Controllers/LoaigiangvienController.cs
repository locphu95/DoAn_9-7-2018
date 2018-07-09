using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoaigiangvienController : Controller
    {
        private AppDbContext _db;
        public LoaigiangvienController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model = from a in  _db.LoaiGiangVien where a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                LoaiGiangVien model = _db.LoaiGiangVien.Find(id);
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
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] LoaiGiangVien cb,string id)
        {
          try{
            LoaiGiangVien edit =_db.LoaiGiangVien.FirstOrDefault(x=>x.MaLoaiGiangVien==id);       
              edit.TenLoaiGiangVien=cb.TenLoaiGiangVien;
              edit.BaoHiem=cb.BaoHiem;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpGet("Delete/{id}")]
         public IActionResult Post3(string id)
        {
          try{
            LoaiGiangVien del =_db.LoaiGiangVien.FirstOrDefault(x=>x.MaLoaiGiangVien==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost]
      public IActionResult Post([FromBody] LoaiGiangVien cb)
        {
          cb.TrangThai=true;
          try
          {
            LoaiGiangVien tour=new LoaiGiangVien(){
                MaLoaiGiangVien=cb.MaLoaiGiangVien,
                TenLoaiGiangVien=cb.TenLoaiGiangVien,
                BaoHiem= cb.BaoHiem,
                TrangThai=cb.TrangThai
            };
            _db.LoaiGiangVien.Add(tour);
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }



    }


}
