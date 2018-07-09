using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class cbnvController : Controller
    {
        private AppDbContext _db;
        public cbnvController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{mahk}/{manh}")]
        public IActionResult Get(string mahk, string manh)
        {
            var model = _db.HocKy.Where(x => x.MaNamHoc == manh && x.MaHocKy == mahk).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model =_db.CBNV.Where(x=>x.TrangThai==true).ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetCb(string id)
        {
          try
          {
            CBNV cb=_db.CBNV.Find(id);
            return Ok(cb);
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
           var model = (from cb in _db.CBNV
                join l in _db.LoaiGiangVien
                on cb.MaLoaiGiangVien equals l.MaLoaiGiangVien
                join ql in _db.ChiTietQuanLy
                on cb.MaCBNV equals ql.MaCBNV
                join dv in _db.DonVi
                on ql.MaDonVi equals dv.MaDonVi
                join cv in _db.ChucVu
                on ql.MaChucVu equals cv.MaChucVu
                where cb.MaCBNV==id
            select new 
              { 
                cb.MaCBNV,cb.HoCBNV,cb.TenCBNV,cb.HocVi,cb.NTNS,dv.TenDonVi,cv.TenChucVu,cb.Phai,
                cb.DienThoai,cb.DiaChi
              });

         // var model = _db.CBNV.ToList();
            return Ok(model);
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }
      [HttpPost]
      public IActionResult Post([FromBody] CBNV cb)
        {
          cb.TrangThai=true;
          try
          {
            CBNV tour=new CBNV(){
                MaCBNV=cb.MaCBNV,
                HoCBNV=cb.HoCBNV,
                TenCBNV=cb.TenCBNV,
                MaLoaiGiangVien=cb.MaLoaiGiangVien,
                MaQuyen=cb.MaQuyen,
                NTNS=cb.NTNS,
                Email=cb.Email,
                DiaChi=cb.DiaChi,
                DienThoai=cb.DienThoai,
                TenDangNhap=cb.TenDangNhap,
                MatKhau=cb.MatKhau,
                TrangThai=cb.TrangThai
            };
            _db.CBNV.Add(tour);
            _db.SaveChanges();
            return Ok("Them thanh cong");
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }
        [HttpPost("Edit/{id}")]
         public IActionResult Post2([FromBody] CBNV cb,string id)
        {
          try{
            CBNV edit =_db.CBNV.FirstOrDefault(x=>x.MaCBNV==id);
              edit.HoCBNV=cb.HoCBNV;
              edit.TenCBNV=cb.TenCBNV;
              edit.MaLoaiGiangVien=cb.MaLoaiGiangVien;
              edit.MaQuyen=cb.MaQuyen;
              edit.NTNS=cb.NTNS;
              edit.Email=cb.Email;
              edit.DiaChi=cb.DiaChi;
              edit.DienThoai=cb.DienThoai;
              edit.TenDangNhap=cb.TenDangNhap;
              edit.MatKhau=cb.MatKhau;
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
            CBNV del =_db.CBNV.FirstOrDefault(x=>x.MaCBNV==id);
             del.TrangThai = false;
            _db.SaveChanges();
            return Ok("Xoa thanh cong");
          }
          catch{
             return BadRequest();
          }
        }
       [HttpGet("Seach/{id}")]
        public IActionResult Post4(string id)
        {
          try
          {
           var model = from m in _db.CBNV 
            where m.HoCBNV.Contains(id) || m.TenCBNV.Contains(id)
            select m;

         // var model = _db.CBNV.ToList();
            return Ok(model);
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }
  }
}
