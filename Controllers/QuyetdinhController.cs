using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QuyetdinhController : Controller
    {
        private AppDbContext _db;
        public QuyetdinhController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var model = (from qd in _db.QuyetDinh join cb in _db.CBNV on qd.MaCBNV equals cb.MaCBNV
                            join lqd in _db.LoaiQuyetDinh on qd.MaLoaiQuyetDinh equals lqd.MaLoaiQuyetDinh
            where qd.TrangThai==true select new {
                qd, cb,lqd
            }).Distinct();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                var model =(from a in _db.QuyetDinh
                            join b in _db.CBNV on a.MaCBNV equals b.MaCBNV
                            join c in _db.LoaiQuyetDinh on a.MaLoaiQuyetDinh equals c.MaLoaiQuyetDinh
                            where a.SoQuyetDinh == id
                            select new { a.SoQuyetDinh,a.MaCBNV,a.NgayBanHanh,a.NoiDungQuyetDinh,
                            a.ThoiHan,a.HinhThuc, a.LoaiQuyetDinh,c.TenLoaiQuyetDinh, b.HoCBNV,b.TenCBNV}).SingleOrDefault();
                return Ok(model);   
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(string id)
        {
            try
            {
                var model = (from qd in _db.QuyetDinh join cb in _db.CBNV on qd.MaCBNV equals cb.MaCBNV
                            join lqd in _db.LoaiQuyetDinh on qd.MaLoaiQuyetDinh equals lqd.MaLoaiQuyetDinh
                            where qd.SoQuyetDinh == id
                            select new {
                qd, cb,lqd
            }).Distinct();
            return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] QuyetDinh cb,string id)
        {
          try{
            QuyetDinh edit =_db.QuyetDinh.FirstOrDefault(x=>x.SoQuyetDinh==id);
              edit.MaCBNV=cb.MaCBNV;
              edit.MaLoaiQuyetDinh=cb.MaLoaiQuyetDinh;
              edit.NgayBanHanh=cb.NgayBanHanh;
              edit.NoiDungQuyetDinh=cb.NoiDungQuyetDinh;
              edit.HinhThuc=cb.HinhThuc;
              edit.ThoiHan=cb.ThoiHan;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost]
      public IActionResult Post([FromBody] QuyetDinh qd)
        {
          qd.TrangThai=true;
          try
          {
            QuyetDinh tour=new QuyetDinh(){
                SoQuyetDinh=qd.SoQuyetDinh,
                MaCBNV=qd.MaCBNV,
                MaLoaiQuyetDinh=qd.MaLoaiQuyetDinh,
                ThoiHan=qd.ThoiHan,
                NgayBanHanh=qd.NgayBanHanh,
                NoiDungQuyetDinh=qd.NoiDungQuyetDinh,
                HinhThuc=qd.HinhThuc,
                TrangThai=qd.TrangThai
            };
            _db.QuyetDinh.Add(tour);
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
            QuyetDinh del =_db.QuyetDinh.FirstOrDefault(x=>x.SoQuyetDinh==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }



    }


}
