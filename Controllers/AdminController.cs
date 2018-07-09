using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NguyenPhuLoc.Models;

namespace NguyenPhuLoc.Controllers
{
    public class AdminController : Controller
    {
          private AppDbContext _db;
        public AdminController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Cbnv()
        {
            return View();
        }
         public IActionResult Quyetdinh()
        {
            return View();
        }
         public IActionResult Quyen()
        {
            return View();
        }
         public IActionResult Chucvu()
        {
            return View();
        }
         public IActionResult Loaigiangvien()
        {
            return View();
        }
         public IActionResult Namhoc()
        {
            return View();
        }
         public IActionResult Hocky()
        {
            return View();
        }
         public IActionResult Hotro()
        {
            return View();
        }
         public IActionResult Congviec()
        {
            return View();
        }
         public IActionResult Donvi()
        {
            return View();
        }
         public IActionResult Nhiemvu()
        {
            return View();
        }
         public IActionResult Quydinh()
        {
            return View();
        }
        public IActionResult Danhmucnghiepvu()
        {
            return View();
        } 
        public IActionResult Danhmucquanly()
        {
            return View();
        }
          public IActionResult Chaomung()
        {
            return View();
        } 
        public IActionResult ThongKe()
        {
            return View();
        }


        public IActionResult Thongkekhoa()
        {
            return View();
        }
          public IActionResult Phieudangky()
        {
            return View();
        }

               public IActionResult Xinhotro()
        {
            return View();
        }
               public IActionResult Minhchung()
        {
            return View();
        }
        public IActionResult Danhgia()
        {
            return View();
        }
        public IActionResult Chitietquanly()
        {
            return View();
        }
    }
}
