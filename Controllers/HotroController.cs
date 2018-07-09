using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HotroController : Controller
    {
        private AppDbContext _db;
        public HotroController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model =from a in _db.HoTro where  a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.HoTro.Find(id);
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
        public IActionResult Post([FromBody] HoTro cb)
        {
          cb.TrangThai=true;
          try
          {
            HoTro tour=new HoTro(){
                MaHoTro=cb.MaHoTro,
                NguonHoTro=cb.NguonHoTro,
                LoaiHoTro= cb.LoaiHoTro,
                SoLuong=cb.SoLuong,
                DonViTinh = cb.DonViTinh,
                TrangThai=cb.TrangThai
            };
            _db.HoTro.Add(tour);
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
            HoTro del =_db.HoTro.FirstOrDefault(x=>x.MaHoTro==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] HoTro cb,string id)
        {
          try{
            HoTro edit =_db.HoTro.FirstOrDefault(x=>x.MaHoTro==id);
              edit.NguonHoTro=cb.NguonHoTro;
              edit.LoaiHoTro=cb.LoaiHoTro;
              edit.SoLuong=cb.SoLuong;
              edit.DonViTinh=cb.DonViTinh;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
    }


}
