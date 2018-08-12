using MarketNFC.Models;
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



        Dictionary<String, int> prodDict = new Dictionary<String, int>();

        
        //HashSet<String, int> prodDict = new HashSet<Produkt, int>();

        //zamowienieUzytkownika.foireach(s =>
        //    {
        //        s.produkt.foreach(prod =>
        //        {
        //            if(prodDict.Has(prod.id))
                        
        //        }
        //    )
        //    }
        //    )
    }
}
