using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MarketNFC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Uzytkownik : IdentityUser
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataRejestracji { get; set; }
    }
}
