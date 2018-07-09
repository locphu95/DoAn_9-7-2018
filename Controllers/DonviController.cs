using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DonviController : Controller
    {
        private AppDbContext _db;
        public DonviController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model =from a in _db.DonVi where  a.TrangThai==true select a;
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetNH(string id)
        {
            var model= _db.DonVi.Find(id);
            return Ok(model);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(string id)
        {
            try
            {
                var model = (from dv in _db.DonVi 
                             join ctql in _db.ChiTietQuanLy on dv.MaDonVi equals ctql.MaDonVi
                             join cbnv in _db.CBNV on ctql.MaCBNV equals cbnv.MaCBNV
                             where dv.MaDonVi==id && ctql.MaChucVu=="TK" 
                             select new
                             {
                                 dv.MaDonVi,dv.TenDonVi,dv.DienThoai,cbnv.TenCBNV,cbnv.HoCBNV,cbnv.HocVi,
                             }).ToList();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] DonVi cb)
        {
          cb.TrangThai=true;
          try
          {
            DonVi tour=new DonVi(){
                MaDonVi=cb.MaDonVi,
                TenDonVi=cb.TenDonVi,
                DienThoai= cb.DienThoai,
                TrangThai=cb.TrangThai
            };
            _db.DonVi.Add(tour);
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
            DonVi del =_db.DonVi.FirstOrDefault(x=>x.MaDonVi==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] DonVi cb,string id)
        {
          try{
            DonVi edit =_db.DonVi.FirstOrDefault(x=>x.MaDonVi==id);
              edit.TenDonVi=cb.TenDonVi;
              edit.DienThoai=cb.DienThoai;
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
    }


}
