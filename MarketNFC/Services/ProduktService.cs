using MarketNFC.Data;
using MarketNFC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Services
{
    public class ProduktService
    {


        private readonly ApplicationDbContext _context;

        public ProduktService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produkt> GetProdukty()
        {
            return _context.Produkty
                .Include("ZamowienieProdukty.Zamowienie")
                .Include("StanLodowki.Lodowka")
                .Include("UpodobanieUzytkownikow.Uzytkownik");
        }

        public Produkt GetProdukt(int id)
        {
            var produkt = _context.Produkty
                .FirstOrDefault(p => p.ProduktId == id);

            return produkt;
        }

        public Produkt GetByTag(string tag)
        {
            var produkt = _context.Produkty
                .FirstOrDefault(p => p.RFIDTag == tag);

            return produkt;
        }

        public void PostProdukt(Produkt produkt)
        {
            _context.Produkty.Add(produkt);
            _context.SaveChanges();
        }

        public void PostProduktLodowka(Produkt produkt)
        {
            //bo normalnie bedzie tak ze jak bedziesz postowal produkt to dasz jedna lodowke w tkorej bedzie np jej ID lub nazwa lub cos innego
            //ponizej przykladowy json
            var lodowka = _context.Lodowki
                .FirstOrDefault(l => l.LodowkaId == produkt.Lodowki.First().LodowkaId);

            produkt.Lodowki.Add(lodowka);

            _context.Produkty.Add(produkt);
            _context.SaveChanges();
        }

        /*
         {
    "produktId": 1,
    "nazwa": "SZAMPON",
    "rfidTag": "1111",
    "dataWaznosci": "2018-08-17T19:44:02.299",
    "producent": "SYOSS",
    "globalnyNumerJednostkiHandlowej": 1111,
    "numerPartiiProdukcyjnej": 1111,
    "cena": 5,
    "lodowki": [
        {
            "lodowkaId": 1,
            "pojemnosc": 10,
            "dataAktualizacji": "2018-08-17T19:44:02.295",
        }
        ]
}
         */



    }
}
