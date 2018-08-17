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
            var produkty = lodowka.Produkty;

            //znajdz lodowke wsrod tych ktore sa w bazie
            var lod = _context.Lodowki
                .Include("StanLodowki.Produkt")
                .FirstOrDefault(l => l.LodowkaId == id);

            // usuwanie
            //List<Produkt> prodList = lod.Produkty.ToList();
            //foreach (var produkt in produkty)
            //{
            //    if (prodList.Exists(p => p.ProduktId == produkt.ProduktId))
            //        lod.Produkty.Remove(produkt);
            //}

            // i teraz jakas logika zeby sprawdzic czy produkt zostanie usuniety z lodowki czy dodany.
            // Narazie zaimplementuje ze dodany. Tak naprawde mozna zalozyc ze edycja to usuniecie a potem dodanie ale robi sie duzo ID
            foreach (var produkt in produkty)
            {
                lod.Produkty.Add(produkt);
            }

            lodowka.DataAktualizacji = DateTime.Now;

            return lod;
        }
    }
}
