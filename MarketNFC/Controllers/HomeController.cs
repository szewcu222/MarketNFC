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

            //var p = _db.Produkty.Find(1);

            ViewData["Zwrotka"] = "cos";
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

            //var u = zam.Uzytkownik;

            var zamowienia = _db.Zamowienia
                //.Include(e => e.Uzytkownik)
                //.Include(l => l.Lodowka)
                //.Include(e => e.ZamowienieProdukty)
                //.ThenInclude(e => e.Produkt)
                .ToList();

            var listProd = new List<Produkt>();
            foreach (var zamow in zamowienia)
            {
                //zamow.ZamowienieProdukty


                //foreach (var tag in post.ZamowienieProdukty.Select(e => e.Produkt))
                //{
                //    //Console.WriteLine($"    Tag {tag.RFIDTag}");
                //}
            }

            //var prod = _db.ZamowieniaProdukty
            //    .Where(z => )
            //    .wher
            //    .Include(p => p.Produkt)



            var zam = _db.Zamowienia.
                Include("ZamowienieProdukty.Produkt")
                .ToList();

            //_db.Entry(zam).Collection(b => b.)


            //_db.Zamowienia.FirstOrDefault(u => u.ZamowienieProdukty.FirstOrDefault(f => f.ZamowienieId == 1));

            return zam;
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

        public JsonResult GetProdukt()
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
        Uzytkownik user;
        public IActionResult Congrats()
        {
            ViewData["Message"] = "Congrats";
            GetCurrentUser();
            String username = _userManager.GetUserName(HttpContext.User);
            var user = _db.Users.FirstOrDefault(u => u.UserName == username);

            var userGrupa = _db.UzytkownicyGrupy.
                Where(g => g.UzytkownikId == user.Id).
                FirstOrDefault();

            Grupa grupa;
            if (userGrupa == null)
            {
                grupa = _db.Grupy.FirstOrDefault();
                grupa.Uzytkownicy.Add(user);
                _db.Grupy.Update(grupa);
                _db.SaveChanges();
            }
            else
                grupa = _db.Grupy.Find(userGrupa.GrupaId);


            var lodowka = _db.Lodowki.
                Where(l => l.GrupaId == grupa.GrupaId).
                FirstOrDefault();

            ViewData["lodowkaPoj"] = lodowka.Pojemnosc;
            ViewData["lodowkaID"] = lodowka.LodowkaId;
            ViewData["grupa"] = grupa.Nazwa;
            ViewData["username"] = username;
            return View();
        }

        private async Task<Uzytkownik> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        private async void GetCurrentUser()
        {
            
            //GetCurrentUserAsync()
            user = await GetCurrentUserAsync();
        }
    }
}
