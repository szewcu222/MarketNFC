using MarketNFC.Data;
using MarketNFC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Services
{
    public class LodowkaService
    {
        private readonly ApplicationDbContext _context;

        public LodowkaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lodowka> GetLodowki()
        {
            return _context.Lodowki
                .Include("StanLodowki.Produkt");
        }

        public Lodowka GetLodowka(int id)
        {
            return _context.Lodowki
                .Include("StanLodowki.Produkt")
                .FirstOrDefault(l => l.LodowkaId == id);
        }

        public void PostLodowka(Lodowka lodowka)
        {
            _context.Lodowki.Add(lodowka);
            _context.SaveChanges();
        }

        internal Lodowka PutLodowka(int id, Lodowka lodowka)
        {
            //pobierz produkty ktore poszly w jsonie
            List<Produkt> noweProdukty = new List<Produkt>();
            foreach(var prod in lodowka.Produkty)
            {
                noweProdukty.Add(_context.Produkty.
                    Where(x => x.RFIDTag == prod.RFIDTag).
                    FirstOrDefault());
            }
            
            //znajdz lodowke wsrod tych ktore sa w bazie
            var lodowkaDb = _context.Lodowki
                .AsNoTracking()
                .Include("StanLodowki.Produkt")
                .FirstOrDefault(l => l.LodowkaId == id);

            //usun dotychczasowe produkty przypisane do lodowki
            lodowkaDb.Produkty.Clear();

            //pobierz wszystkie rekordy z tabeli StanLodowki dot. 
            //postowanej lodowki
            var st_l = _context.StanyLodowek
                .Where(x => x.LodowkaId == lodowka.LodowkaId);

            //usun rekordy stanu lodowki
            if (st_l.Count<StanLodowki>() > 0)
            {
                foreach (var st in st_l)
                {
                    _context.StanyLodowek.Remove(st);
                }
            }

            //zapisz nowy stan lodowki w bazie danych
            if (noweProdukty.Count > 0)
            {
                foreach (var produkt in noweProdukty)
                {
                    lodowkaDb.Produkty.Add(produkt);

                    _context.StanyLodowek.Add(new StanLodowki
                    {
                        ProduktId = produkt.ProduktId,
                        LodowkaId = lodowka.LodowkaId,
                        Ilosc = 1
                    });
                }
            }

            lodowkaDb.DataAktualizacji = DateTime.Now;

            return lodowkaDb;
        }

        /*
           {
        "lodowkaId": 1,
        "pojemnosc": 10,
        "dataAktualizacji": "2018-08-17T19:44:02.295",
        "grupaId": 1,
        "grupa": null,
        "zamowienia": [],
        "produkty": [
            {
                "produktId": 1,
                "nazwa": "gfgfg",
                "rfidTag": "1111",
                "dataWaznosci": "2018-08-17T19:44:02.299",
                "producent": "SYOSS",
                "globalnyNumerJednostkiHandlowej": 1111,
                "numerPartiiProdukcyjnej": 1111,
                "cena": 5,
                "zamowienia": [],
                "uzytkownicy": [],
                "lodowki": []
            },
            {
                "produktId": 2,
                "nazwa": "COLA",
                "rfidTag": "2222",
                "dataWaznosci": "2018-08-17T19:44:02.3",
                "producent": "SYOSS",
                "globalnyNumerJednostkiHandlowej": 2222,
                "numerPartiiProdukcyjnej": 2222,
                "cena": 10,
                "zamowienia": [],
                "uzytkownicy": [],
                "lodowki": []
            }
            ]
    }
         */

    }
}
