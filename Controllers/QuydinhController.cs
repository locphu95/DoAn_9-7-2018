using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QuydinhController : Controller
    {
        private AppDbContext _db;
        public QuydinhController(AppDbContext db)
        {
            _db = db;
        }
      [HttpGet]
        public IActionResult Get()
        {
            var model =from a in _db.QuyDinh where  a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.QuyDinh.Find(id);
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
        [HttpPost]
        public IActionResult Post([FromBody] QuyDinh cb)
        {
          cb.TrangThai=true;
          try
          {
            QuyDinh tour=new QuyDinh(){
                SoQuyDinh=cb.SoQuyDinh,
                MaNamHoc=cb.MaNamHoc,
                NgayBanHanh= cb.NgayBanHanh,
                NoiDungQuyDinh=cb.NoiDungQuyDinh,
                TrangThai=cb.TrangThai
            };
            _db.QuyDinh.Add(tour);
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
            QuyDinh del =_db.QuyDinh.FirstOrDefault(x=>x.SoQuyDinh==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] QuyDinh cb,string id)
        {
          try{
            QuyDinh edit =_db.QuyDinh.FirstOrDefault(x=>x.SoQuyDinh==id);
              edit.MaNamHoc=cb.MaNamHoc;
              edit.NoiDungQuyDinh=cb.NoiDungQuyDinh;
              edit.NgayBanHanh=cb.NgayBanHanh;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
    }


}
