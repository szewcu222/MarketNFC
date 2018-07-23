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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Imie { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Nazwisko { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DataRejestracji { get; set; }
    }
}
