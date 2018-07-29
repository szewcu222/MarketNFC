using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarketNFC.Models;
using MarketNFC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarketNFC.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<Uzytkownik> _userManager;
        private SignInManager<Uzytkownik> _signManager;
        private ApplicationDbContext _db;

        public HomeController(UserManager<Uzytkownik> userManager, 
            SignInManager<Uzytkownik> signManager)
        {
            _db = ApplicationDbContext.Create();
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult Index()
        {
            var produkt = new Produkt();
            produkt.Nazwa = "Kielba";
            produkt.RFIDTag = "56ghj78900090bcxs";
            produkt.DataWaznosci = DateTime.Now;

            _db.Produkty.Add(produkt);
            _db.SaveChanges();

            var p = _db.Produkty.Find(1);
            
            ViewData["Zwrotka"] = p.Nazwa;
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string Test()
        {
            return "test";
        }

        public JsonResult Produkt()
        {
            var p = _db.Produkty.Find(1);

            return Json(p);
        }
        public JsonResult Zamowienie()
        {
            var p = _db.Produkty.Find(1);
            var z = _db.Zamowienia.Find(1);
            //_db.Zamowienia.FirstOrDefault(u => u.ZamowienieProdukty.FirstOrDefault(f => f.ZamowienieId == 1));

            return Json(z);
        }
        public JsonResult Produkty()
        {
            var p = new List<Produkt> { 
                new Produkt { Nazwa = "Boczek", RFIDTag = "41238cdfshfuia7", DataWaznosci = DateTime.Now },
                new Produkt { Nazwa = "Jagodzianka", RFIDTag = "v98dfc7fddsa0-a", DataWaznosci = DateTime.Now },
                new Produkt { Nazwa = "Maslo", RFIDTag = "ds90a9023iddsaod", DataWaznosci = DateTime.Now }
            };

            return Json(p);
        }
    }
}
