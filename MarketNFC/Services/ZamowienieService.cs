using MarketNFC.Data;
using MarketNFC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Services
{
    public class ZamowienieService
    {
        //TODO
        //Serwis bedzie przyjmowal dane z kontrolera z POSTa zamowienia z androida
        //Na podstawie danych 
        // *wyszuka odpowiedniego uzytkownika, grupe, lodowke(czyli na podstawie id znajdzie cale obiekty)
        // *doda zamowienie, 
        // *sprawdzi czy takie produkty ktore sa w zamowieniu istnieja, jesli nie doda je\
        // *wypelni date dostarczenia
        // *okresli typo zamowienia(ze od uzytkownika a nie od systemu)
        // *zapisywanie do tebeli upodobanie uzytnowika uzytnowik/produkty - odpalany UpodobanieService
        // 

        private readonly ApplicationDbContext _context;

        public ZamowienieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Zamowienie> GetZamowienia()
        {
            return _context.Zamowienia
                .Include("ZamowienieProdukty.Produkt");
        }

        public Zamowienie GetZamowienie(int id)
        {
            return _context.Zamowienia
                .Include("ZamowienieProdukty.Produkt")
                .Where(z => z.ZamowienieId == id)
                .FirstOrDefault();
        }

        public void PostZamowienie(Zamowienie zamowienie)
        {
            //var user = FindUser(zamowienie.Uzytkownik.UserName);
            //zamowienie.Uzytkownik = user;
            zamowienie.Lodowka = _context.Lodowki.Find(1);
            zamowienie.LodowkaId = 1;
            _context.Zamowienia.Add(zamowienie);
            _context.SaveChanges();
        }

        public Zamowienie GetZamowienieUzytkownika(string id)
        {
            return _context.Zamowienia
                .Where(z => z.UzytkownikId == id)
                .Include("ZamowienieProdukty.Produkt")
                .FirstOrDefault();
        }
        //////////////////////////////////    HELP{ERS
        public Uzytkownik FindUser(string username)
        {
            return _context.Users.
                FirstOrDefault(u => u.UserName == username);
        }
    }
}
