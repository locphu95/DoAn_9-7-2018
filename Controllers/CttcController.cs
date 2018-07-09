using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NguyenPhuLoc.Models;


namespace NguyenPhuLoc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CttcController : Controller
    {
        private AppDbContext _db;
        public CttcController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("{manv}/{manh}")]
        public IActionResult Get(string manv, string manh)
        {
            var model = _db.ChiTietToChuc.Where(x => x.MaDonVi == manv && x.MaCongViec == manh).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _db.ChiTietToChuc.ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Getcv(string id)
        {
            try
            {
                ChiTietToChuc model = _db.ChiTietToChuc.Find(id);
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
                var model = (from cb in _db.ChiTietToChuc
                             from l in _db.DonVi
                             where cb.MaDonVi == l.MaDonVi && cb.MaDonVi==id
                             
                             select new
                             {
                                 l.TenDonVi,

                             });
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] ChiTietToChuc ql)
        {
          try
          { 
              ql.TrangThai=true;
            ChiTietToChuc ctql=new ChiTietToChuc(){
                MaCongViec=ql.MaCongViec,
                MaDonVi=ql.MaDonVi,
                DiaDiemToChuc=ql.DiaDiemToChuc,
                TrangThai=ql.TrangThai
            };
            _db.ChiTietToChuc.Add(ctql);
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
