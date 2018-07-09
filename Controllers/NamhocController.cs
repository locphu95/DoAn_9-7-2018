using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NamhocController : Controller
    {
        private AppDbContext _db;
        public NamhocController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model =from a in  _db.NamHoc where a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.NamHoc.Find(id);
            return Ok(model);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(string id)
        {
            try
            {
                var model = (from nh in _db.NamHoc 
                             join hk in _db.HocKy on nh.MaNamHoc equals hk.MaNamHoc
                             where nh.MaNamHoc==id 
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
        public IActionResult Post([FromBody] NamHoc cb)
        {
          cb.TrangThai=true;
          try
          {
            NamHoc tour=new NamHoc(){
                MaNamHoc=cb.MaNamHoc,
                NgayBatDauNamHoc=cb.NgayBatDauNamHoc,
                NgayKetThucNamHoc= cb.NgayKetThucNamHoc,
                MoTaNamHoc=cb.MoTaNamHoc,
                TrangThai=cb.TrangThai
            };
            _db.NamHoc.Add(tour);
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
            NamHoc del =_db.NamHoc.FirstOrDefault(x=>x.MaNamHoc==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] NamHoc cb,string id)
        {
          try{
            NamHoc edit =_db.NamHoc.FirstOrDefault(x=>x.MaNamHoc==id);
              edit.NgayBatDauNamHoc=cb.NgayBatDauNamHoc;
              edit.NgayKetThucNamHoc=cb.NgayKetThucNamHoc;
              edit.MoTaNamHoc=cb.MoTaNamHoc;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
    }


}
