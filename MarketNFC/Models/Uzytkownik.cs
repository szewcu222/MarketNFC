using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            UpodobaniaUzytkownika = new HashSet<UpodobanieUzytkownika>();
        }

        //public int UzytkownikId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataRejestracji { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<UzytkownikGrupa> UzytkownikGrupy { get; set; }
        
        public virtual ICollection<Zamowienie> Zamowienia { get; set; }

        public virtual ICollection<UpodobanieUzytkownika> UpodobaniaUzytkownika{ get; set; }
    }
}
