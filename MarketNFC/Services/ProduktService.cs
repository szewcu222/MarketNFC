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
            return _context.Produkty;
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

        public bool PostProdukt(Produkt produkt)
        {
            if (IsProduktAlreadyExists(produkt.RFIDTag))
                return false;

            _context.Produkty.Add(produkt);
            _context.SaveChanges();

            return true;
        }

        public bool IsProduktAlreadyExists(string rfidUID)
        {
            var produkt = _context.Produkty
                .FirstOrDefault(p => p.RFIDTag == rfidUID);

            if (produkt == null)
                return false;
            else
                return true;
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
