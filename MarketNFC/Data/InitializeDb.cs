using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarketNFC.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace MarketNFC.Data
{
    public static class InitializeDb
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = new UserManager<Uzytkownik>();
                ApplicationDbContext db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - LODOWKA

                var lodowki = new List<Lodowka> {
                new Lodowka { Pojemnosc = 10, GrupaId = 1, DataAktualizacji = DateTime.Now },
                new Lodowka { Pojemnosc = 15, GrupaId = 2, DataAktualizacji = DateTime.Now },
                new Lodowka { Pojemnosc = 12, GrupaId = 3, DataAktualizacji = DateTime.Now }
                };

                foreach (var lodowka in lodowki)
                    db.Lodowki.Add(lodowka);

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - UZYTKOWNIK

                var userzy = new List<Uzytkownik> {
                new Uzytkownik { Email = "szewcu222@gmail.com", Imie = "Darek", Nazwisko = "Malysz" },
                new Uzytkownik { Email = "miska@gmail.com", Imie = "Misia", Nazwisko = "Mis" },
                new Uzytkownik { Email = "sobek44@gmail.com", Imie = "Sebke", Nazwisko = "Szczepankiewicz" },
                new Uzytkownik { Email = "kozula@gmail.com", Imie = "MIchal", Nazwisko = "Kozubek" }
                };

                foreach (var user in userzy)
                    _userManager.CreateAsync(user, "haslo");

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - GRUPA

                var grupy = new List<Grupa> {
                new Grupa { Nazwa = "debesciaki", LodowkaId = 1 },
                new Grupa { Nazwa = "mlode_wilki", LodowkaId = 2 },
                new Grupa { Nazwa = "banda chuja", LodowkaId = 3 }
                };

                foreach (var grupa in grupy)
                    _db.Grupy.Add(grupa);

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - GRUPA


            }
        }
    }
}
}