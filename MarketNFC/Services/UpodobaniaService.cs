using MarketNFC.Data;
using MarketNFC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Services
{
    public class UpodobaniaService
    {
        // Obliczanie upodoban uzytkownika 
        // *odczytuje zamowienia danego uzytkownika. Slownik tych produktow wraz z liczba wystapien. na podstawie tego oblicza wspolczynbnik upodobania i dodaje do tabeli UpodobaniaUzytkownika
        // *dodatkowo metody do getowania tych wierszy zeby na szybkosci byly
        //

        private readonly ApplicationDbContext _context;

        public UpodobaniaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ObliczUpodobaniaUzytkownika(string uzytkownikId)
        {
            var user = _context.Users.Where(u => u.Id == uzytkownikId).FirstOrDefault();

            if (user != null)
            {
                Dictionary<string, float> upodobaniaDict = new Dictionary<string, float>();
                Dictionary<string, int> liczbaWystapienProduktu = new Dictionary<string, int>();

                var zamowienia = _context.Zamowienia
                    .Include("ZamowienieProdukty.Produkt")
                    .Where(z => z.UzytkownikId == uzytkownikId);

                int liczbaZamowienUzytkownika = zamowienia.Count();

                if (liczbaZamowienUzytkownika > 0)
                {
                    //zlicz liczbe wystapien danego produktu we wszystkich zamowieniach
                    foreach (var z in zamowienia)
                    {
                        if (z.Produkty.Count > 0)
                        {
                            foreach (var p in z.Produkty)
                            {
                                if (!liczbaWystapienProduktu.Keys.Contains(p.RFIDTag))
                                {
                                    liczbaWystapienProduktu.Add(p.RFIDTag, 1);
                                }
                                else
                                {
                                    liczbaWystapienProduktu[p.RFIDTag]++;
                                }
                            }
                        }
                    }

                    //oblicz wspolczynnik 'ulubienia' produktu przez uzytkownika
                    if (liczbaWystapienProduktu.Count() > 0)
                    {
                        foreach (var p in liczbaWystapienProduktu)
                        {
                            upodobaniaDict.Add(p.Key, (float)p.Value / liczbaZamowienUzytkownika);
                        }

                        //czynnosci zwiazane z db
                        if (upodobaniaDict.Count > 0)
                        {
                            var popUpodobania = _context.UpodobaniaUzytkownikow
                                .Where(u => u.UzytkownikId == uzytkownikId);

                            //usun dotychczasowe upodobania zapisane w bazie
                            if (popUpodobania.Count() > 0)
                            {
                                foreach (var u in popUpodobania)
                                {
                                    _context.UpodobaniaUzytkownikow.Remove(u);
                                }
                            }

                            //dodaj nowe rekordy z wyliczonymi wspolczynnikami upodobania
                            foreach (var u in upodobaniaDict)
                            {
                                var produkt = _context.Produkty
                                    .Where(p => p.RFIDTag == u.Key)
                                    .FirstOrDefault();

                                _context.UpodobaniaUzytkownikow.Add(
                                    new UpodobanieUzytkownika
                                    {
                                        ProduktId = produkt.ProduktId,
                                        UzytkownikId = uzytkownikId,
                                        WspolczynnikUpodobania = u.Value
                                    }
                                );
                            }
                            _context.SaveChanges();
                        }
                    }
                }
            }
        }

        public SystemOrderViewModel GetDayAndTimeSystemOrder(string userId)
        {
            var user = _context.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if(user == null)
            {
                return new SystemOrderViewModel { 
                    Day = -1
                };
            }

            return new SystemOrderViewModel { 
                Day = user.DzienSysZamowienia, 
                Time = user.GodzinaSysZamowienia
            };
        }

        public void PostDayAndTimeSystemOrder(string userId, SystemOrderViewModel order)
        {
            var user = _context.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            user.DzienSysZamowienia = order.Day;
            user.GodzinaSysZamowienia = order.Time;

            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}
