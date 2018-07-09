using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ChucvuController : Controller
    {
        private AppDbContext _db;
        public ChucvuController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model =from a in _db.ChucVu where  a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.ChucVu.Find(id);
            return Ok(model);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(string id)
        {
            try
            {
                var model = (from nh in _db.NamHoc 
                             join hk in _db.HocKy on nh.MaNamHoc equals hk.MaNamHoc
                             where hk.MaHocKy==id 
                             select new
                             {
                                nh.MaNamHoc,nh.NgayBatDauNamHoc,nh.NgayKetThucNamHoc,nh.MoTaNamHoc,hk.MaHocKy

                             }).ToList();
                var kq = from a in model group a by new{ a.MaNamHoc,a.NgayBatDauNamHoc,a.NgayKetThucNamHoc,a.MoTaNamHoc,a.MaHocKy} into g select new { g.Key.MaNamHoc,g.Key.NgayBatDauNamHoc,g.Key.NgayKetThucNamHoc,g.Key.MoTaNamHoc,g.Key.MaHocKy};
                return Ok(kq);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IActionResult Post([FromBody] ChucVu cb)
        {
          cb.TrangThai=true;
          try
          {
            ChucVu tour=new ChucVu(){
                MaChucVu=cb.MaChucVu,
                TenChucVu=cb.TenChucVu,
                TrangThai=cb.TrangThai
            };
            _db.ChucVu.Add(tour);
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
            ChucVu del =_db.ChucVu.FirstOrDefault(x=>x.MaChucVu==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] ChucVu cb,string id)
        {
          try{
            ChucVu edit =_db.ChucVu.FirstOrDefault(x=>x.MaChucVu==id);
              edit.TenChucVu=cb.TenChucVu;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
    }
}
