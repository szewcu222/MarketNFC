using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models.ApiModels
{
    public class ApiUpodobanieUzytkownika
    {
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        public List<Zamowienie> Zamowienia { get; set; }

        public List<Produkt> Produkty { get; set; }
    }
}
