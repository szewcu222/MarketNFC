using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MarketNFC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Uzytkownik : IdentityUser
    {
        public Uzytkownik()
        {
            UzytkownikGrupy = new HashSet<UzytkownikGrupa>();
            Zamowienia = new HashSet<Zamowienie>();
            UpodobanieUzytkownikow = new HashSet<UpodobanieUzytkownika>();
        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataRejestracji { get; set; }


        public virtual ICollection<UzytkownikGrupa> UzytkownikGrupy { get; set; }
        
        public virtual ICollection<Zamowienie> Zamowienia { get; set; }

        public virtual ICollection<UpodobanieUzytkownika> UpodobanieUzytkownikow { get; set; }
    }
}
