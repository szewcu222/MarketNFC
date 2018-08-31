using MarketNFC.Data;
using MarketNFC.Models;
using MarketNFC.Models.Enums;
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
        private readonly float POZIOM_WSP_ULUB = 0.65f;
        private readonly ApplicationDbContext _context;

        public UpodobaniaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dictionary<string,float> ObliczUpodobaniaUzytkownika(string uzytkownikId)
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
                    return upodobaniaDict;
                }
            }
            return new Dictionary<string, float>();
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

        public Zamowienie SystemOrder(string userId)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return null;

            var userGrupa = _context.UzytkownicyGrupy
                .FirstOrDefault(g => g.UzytkownikId == user.Id);

            if (userGrupa == null)
                return null;

            var grupa = _context.Grupy
                .FirstOrDefault(g => g.GrupaId == userGrupa.GrupaId);

            if (grupa == null)
                return null;

            var lodowka = _context.Lodowki
                .Include("StanLodowki.Produkt")
                .FirstOrDefault(l => l.GrupaId == grupa.GrupaId);

            if (lodowka == null)
                return null;

            if (user != null)
            {
                var ulubioneProdukty = ObliczUpodobaniaUzytkownika(userId);

                List<Produkt> produktyDoZamowienia = new List<Produkt>();
                if (ulubioneProdukty.Count > 0)
                {
                    foreach (var prod in ulubioneProdukty)
                    {
                        if (prod.Value > POZIOM_WSP_ULUB)
                        {
                            if(!lodowka.Produkty.Any(p => p.RFIDTag == prod.Key))
                            {
                                produktyDoZamowienia.Add(_context.Produkty
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.RFIDTag == prod.Key)
                                   );
                            }
                        }
                    }

                    var zamowienie = new Zamowienie
                    {
                        TypZamowienia = TypeOrder.SysOrder,
                        DataZamowienia = DateTime.Now,
                        UzytkownikId = user.Id,
                        LodowkaId = lodowka.LodowkaId ,
                        Produkty = produktyDoZamowienia                       
                    };

                    return zamowienie;
                }
            }
            return null;
        }
    }
}
