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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

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
            //_db.SaveChanges();

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
        public List<Zamowienie> Zamowienie()
        {
            var p = _db.Produkty.Find(1);
            var zam = _db.Zamowienia.Find(1);

            //var q = _db.Zamowienia
            //    .Include(z => z.ZamowienieProdukty)
            //        .ThenInclude(prod => prod.Produkt)
            //    .Include(z => z.Uzytkownik).
            //        FirstOrDefault();

            var q = _db.Zamowienia
                //.Include(z => z.ZamowienieProdukty)
                //.ThenInclude(za => za.Produkt)
                //.Include(z => z.Uzytkownik)
                //.Include(z => z.Lodowka)
                .FirstOrDefault();

            ZamowienieProdukt zampro = new ZamowienieProdukt
            {
                Zamowienie = q,
                Produkt = p
            };


            // przegladarka zwraca niepelnego jsona a Postman sie wysypuje i totalnie nic nie zwraca
            // dodatkowo jezeli chce sie zapytac przez postmana nie mozna dawac na localhost tylko konkretne ip np http://192.168.0.20:44371/home/zamowienie
            // trzeba skonfigurowac zeby mozna bylo z zewnatrz pytac na localhosta .vs/config/applicationhost.config
            // jeden z pierwszych commitow Added config to allow remote connection

            var u = zam.Uzytkownik;

            var posts = _db.Zamowienia
                .Include(e => e.ZamowienieProdukty)
                .ThenInclude(e => e.Produkt)
                .ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"  Post {post.ZamowienieId}");
                foreach (var tag in post.ZamowienieProdukty.Select(e => e.Produkt))
                {
                    Console.WriteLine($"    Tag {tag.RFIDTag}");
                }
            }



            //_db.Zamowienia.FirstOrDefault(u => u.ZamowienieProdukty.FirstOrDefault(f => f.ZamowienieId == 1));

            return posts;
            //return Json(zampro);
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

        public JsonResult GetProdukt ()
        {
            var p = _db.Produkty.Find(1);
            return Json(p);
        }

        //http://192.168.0.20:44371/home/post
    //           {
	   // "nazwa":"BROWAT",
	   // "rfidTag":"1111",
	   // "dataWaznosci":"2018-07-29T23:08:56.413",
	   // "producent":"TYSKIE",
	   // "globalnyNumerJednostkiHandlowej":1111,
	   // "numerPartiiProdukcyjnej":1111,"cena":5.0,
	   // "stanLodowki":[],"zamowienieProdukty":[],
	   // "upodobanieUzytkownikow":[]
    //}


    public void PostProdukt([FromBody]JObject value)
        {
            Produkt posted = value.ToObject<Produkt>();

            _db.Produkty.Add(posted);
            _db.SaveChanges();
            
        }

    }
}
