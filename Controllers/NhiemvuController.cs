using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NhiemvuController : Controller
    {
        private AppDbContext _db;
        public NhiemvuController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model =from a in  _db.NhiemVu where a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.NhiemVu.Find(id);
            return Ok(model);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(string id)
        {
            try
            {
                var model = (from nh in _db.NhiemVu 
                             join hk in _db.CongViec on nh.MaNhiemVu equals hk.MaNhiemVu
                             where nh.MaNhiemVu==id 
                             select new
                             {
                                nh.MaNhiemVu,nh.TenNhiemVu,hk.TenCongViec

                             }).ToList();
                var kq = from a in model group a by new{   a.MaNhiemVu,a.TenNhiemVu,a.TenCongViec } into g select new { g.Key.MaNhiemVu,g.Key.TenNhiemVu,g.Key.TenCongViec};
                return Ok(kq);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IActionResult Post([FromBody] NhiemVu cb)
        {
          cb.TrangThai=true;
          try
          {
            NhiemVu tour=new NhiemVu(){
                MaNhiemVu=cb.MaNhiemVu,
                TenNhiemVu=cb.TenNhiemVu,
                TrangThai=cb.TrangThai
            };
            _db.NhiemVu.Add(tour);
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
            NhiemVu del =_db.NhiemVu.FirstOrDefault(x=>x.MaNhiemVu==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] NhiemVu cb,string id)
        {
          try{
            NhiemVu edit =_db.NhiemVu.FirstOrDefault(x=>x.MaNhiemVu==id);
              edit.TenNhiemVu=cb.TenNhiemVu;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }




    }


}
