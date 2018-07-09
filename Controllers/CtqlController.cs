using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CtqlController : Controller
    {
        private AppDbContext _db;
        public CtqlController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{mahk}/{manh}")]
        public IActionResult Get(string mahk, string manh, string ma)
        {
            var model = _db.ChiTietNhiemVu.Where(x => x.MaNhiemVu == manh && x.MaLoaiGiangVien == mahk && x.MaNamHoc == ma).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _db.ChiTietQuanLy.ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                ChiTietNhiemVu model = _db.ChiTietNhiemVu.Find(id);
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
        [HttpPost("Add")]
        public IActionResult Post([FromBody] ChiTietQuanLy ql)
        {
          try
          {  
              ql.NgayQuyetDinh= DateTime.Now;
              ql.TrangThai=true;
            ChiTietQuanLy ctql=new ChiTietQuanLy(){
                MaCBNV=ql.MaCBNV,
                NgayQuyetDinh=ql.NgayQuyetDinh,
                MaDonVi=ql.MaDonVi,
                MaChucVu=ql.MaChucVu,
                ThoiHan=ql.ThoiHan,
                TrangThai=ql.TrangThai
            };
            _db.ChiTietQuanLy.Add(ctql);
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
