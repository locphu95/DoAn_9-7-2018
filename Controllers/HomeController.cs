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
    public class HomeController : Controller
    {
          private AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cbnv()
        {
            return View();
        }
        public IActionResult Cv()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string id, string pass)
        {
             List<CBNV> list = new List<CBNV>();
             CBNV temp = new CBNV();
            var us = _db.CBNV.SingleOrDefault(x => x.TenDangNhap == id && x.MatKhau == pass);
            if (us == null)
            {
                ViewBag.mess = "Sai tài khoản hoặc mật khẩu !";
                return View();
            }
            else
            {  
                return RedirectToAction("ChaoMung", "Admin");
            }
        }
        public IActionResult Test(){
            return View();
        }

    }
     public static class SessionExtensions
    {
        public static void SetSession(this ISession session, string key, object value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
