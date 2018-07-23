using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarketNFC.Models;
using MarketNFC.Data;

namespace MarketNFC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var db = ApplicationDbContext.Create();

            var produkt = new Produkt();
            produkt.Nazwa = "Kielba";
            produkt.RFIDTag = "56ghj78900090bcxs";
            produkt.DataWaznosci = DateTime.Now;

            db.Produkty.Add(produkt);
            db.SaveChanges();

            var p = db.Produkty.Find(1);
            
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


    }
}
