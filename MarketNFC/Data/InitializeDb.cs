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
using MarketNFC.Models.Enums;

namespace MarketNFC.Data
{
    public static class InitializeDb
    {
        public static void Seed(IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Uzytkownik>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - LODOWKA

                var lodowki = new List<Lodowka> {
                    new Lodowka { Pojemnosc = 10, GrupaId = 1, DataAktualizacji = DateTime.Now },
                    new Lodowka { Pojemnosc = 15, GrupaId = 2, DataAktualizacji = DateTime.Now },
                    new Lodowka { Pojemnosc = 12, GrupaId = 3, DataAktualizacji = DateTime.Now }
                };

                lodowki.ForEach(x => db.Lodowki.Add(x));
                db.SaveChangesAsync();

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - UZYTKOWNIK

                var userzy = new List<Uzytkownik> {
                    new Uzytkownik { Email = "szewcu222@gmail.com", Imie = "Darek", Nazwisko = "Malysz" },
                    new Uzytkownik { Email = "miska@gmail.com", Imie = "Misia", Nazwisko = "Mis" },
                    new Uzytkownik { Email = "sobek44@gmail.com", Imie = "Sebke", Nazwisko = "Szczepankiewicz" },
                    new Uzytkownik { Email = "kozula@gmail.com", Imie = "MIchal", Nazwisko = "Kozubek" }
                };

                userzy.ForEach(x => userManager.CreateAsync(x, "haslo"));
                db.SaveChangesAsync();

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - GRUPA

                var grupy = new List<Grupa> {
                    new Grupa { Nazwa = "debesciaki" },
                    new Grupa { Nazwa = "mlode_wilki" },
                    new Grupa { Nazwa = "banda chuja"}
                };

                grupy.ForEach(x => db.Grupy.Add(x));
                db.SaveChangesAsync();

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - PRODUKT

                var produkty = new List<Produkt> {
                    new Produkt {Nazwa = "Kielbasa",    RFIDTag = "SDSA532131289DSA", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Twarozek",    RFIDTag = "372819D7SADSA789", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Pizza",       RFIDTag = "3421DHSJAKDFAS3D", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Kabanosy",    RFIDTag = "90GFDSGHFJDSKGGF", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "CocaCola",    RFIDTag = "DFSAFDSA2432341C", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Chipsy",      RFIDTag = "NBGHJ48DNBCIU489", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Cisowianka",  RFIDTag = "012234187CDHSFDS", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Jogurt",      RFIDTag = "43298DSADA213144", DataWaznosci = DateTime.Now},
                    new Produkt {Nazwa = "Maslo",       RFIDTag = "75643643FDSFSASA", DataWaznosci = DateTime.Now}
                };

                produkty.ForEach(x => db.Produkty.Add(x));
                db.SaveChangesAsync();

                // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ZAMOWIENIA

                var zamowienia = new List<Zamowienie> {
                    new Zamowienie {LodowkaId = 1, DataZamowienia = DateTime.Now, DataDostarczenia = DateTime.Now, TypZamowienia = TypeOrder.SysOrder},
                    new Zamowienie {LodowkaId = 1, DataZamowienia = DateTime.Now, DataDostarczenia = DateTime.Now, TypZamowienia = TypeOrder.UserOrder},
                    new Zamowienie {LodowkaId = 2, DataZamowienia = DateTime.Now, DataDostarczenia = DateTime.Now, TypZamowienia = TypeOrder.UserOrder},
                    new Zamowienie {LodowkaId = 3, DataZamowienia = DateTime.Now, DataDostarczenia = DateTime.Now, TypZamowienia = TypeOrder.SysOrder}
                };

                zamowienia.ForEach(x => db.Zamowienia.Add(x));
                db.SaveChangesAsync();

                /* na podstawie tego linku i kurwa nie dziala
                https://dzone.com/articles/how-to-seed-your-database-with-ef-core
                 */
            }
        }
    }
}