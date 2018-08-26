using MarketNFC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lodowka>().HasData(
                new Lodowka
                {
                    LodowkaId = 1,
                    Pojemnosc = 10,
                    GrupaId = 1,
                    DataAktualizacji = DateTime.Now,
                },
                new Lodowka
                {
                    LodowkaId = 2,
                    Pojemnosc = 15,
                    GrupaId = 2,
                    DataAktualizacji = DateTime.Now,
                },
                new Lodowka
                {
                    LodowkaId = 3,
                    Pojemnosc = 12,
                    GrupaId = 3,
                    DataAktualizacji = DateTime.Now,
                }
                );


            modelBuilder.Entity<StanLodowki>().HasData(
                        new StanLodowki() { LodowkaId = 1, ProduktId = 1, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 1, ProduktId = 2, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 1, ProduktId = 3, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 2, ProduktId = 3, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 2, ProduktId = 4, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 2, ProduktId = 5, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 3, ProduktId = 2, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 3, ProduktId = 3, Ilosc = 3 },
                        new StanLodowki() { LodowkaId = 3, ProduktId = 4, Ilosc = 3 }
                );

            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik { Id = "1", Email = "szewcu222@gmail.com", Imie = "Darek", Nazwisko = "Malysz", DataRejestracji = DateTime.Now },
                new Uzytkownik { Id = "2", Email = "miska@gmail.com", Imie = "Misia", Nazwisko = "Mis", DataRejestracji = DateTime.Now },
                new Uzytkownik { Id = "3", Email = "sobek44@gmail.com", Imie = "Sebke", Nazwisko = "Szczepankiewicz", DataRejestracji = DateTime.Now },
                new Uzytkownik { Id = "4", Email = "kozula@gmail.com", Imie = "MIchal", Nazwisko = "Kozubek", DataRejestracji = DateTime.Now }
                    );

            modelBuilder.Entity<UzytkownikGrupa>().HasData(
                new UzytkownikGrupa() { GrupaId = 1, UzytkownikId = "1" },
                new UzytkownikGrupa() { GrupaId = 2, UzytkownikId = "3" },
                new UzytkownikGrupa() { GrupaId = 3, UzytkownikId = "3" }
                );



            modelBuilder.Entity<Grupa>().HasData(
                    new Grupa
                    {
                        GrupaId = 1,
                        Nazwa = "debesciaki",
                    },
                    new Grupa
                    {
                        GrupaId = 2,
                        Nazwa = "mlode_wilki",
                    },
                    new Grupa
                    {
                        GrupaId = 3,
                        Nazwa = "banda chuja",
                    }
                );

            modelBuilder.Entity<Zamowienie>().HasData(
                    new Zamowienie
                    {
                        ZamowienieId = 1,
                        UzytkownikId = "1",
                        LodowkaId = 1,
                    },
                     new Zamowienie
                     {
                         ZamowienieId = 2,
                         UzytkownikId = "2",
                         LodowkaId = 1,
                     },
                     new Zamowienie
                     {
                         ZamowienieId = 3,
                         UzytkownikId = "2",
                         LodowkaId = 2,
                     }
                );

            modelBuilder.Entity<ZamowienieProdukt>().HasData(
                            new ZamowienieProdukt() { ZamowienieId = 1, ProduktId = 1, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 1, ProduktId = 2, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 1, ProduktId = 3, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 2, ProduktId = 1, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 2, ProduktId = 2, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 2, ProduktId = 3, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 3, ProduktId = 3, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 3, ProduktId = 4, Ilosc = 2 },
                            new ZamowienieProdukt() { ZamowienieId = 3, ProduktId = 5, Ilosc = 2 }
                );

            modelBuilder.Entity<Produkt>().HasData(
                    new Produkt()
                    {
                        ProduktId = 1,
                        Nazwa = "Jajka L",
                        RFIDTag = "1111",
                        DataWaznosci = DateTime.Now,
                        GlobalnyNumerJednostkiHandlowej = "1111",
                        NumerPartiiProdukcyjnej = "1111",
                        Cena = 5.00F,
                        Producent = "AleJaja",
                    },
                    new Produkt()
                    {
                        ProduktId = 2,
                        Nazwa = "Mleko",
                        RFIDTag = "0419903aec4c80",
                        DataWaznosci = DateTime.Now,
                        GlobalnyNumerJednostkiHandlowej = "2222",
                        NumerPartiiProdukcyjnej = "2222",
                        Cena = 2.99F,
                        Producent = "Mlekpol",
                    },
                    new Produkt()
                    {
                        ProduktId = 3,
                        Nazwa = "Maslo",
                        RFIDTag = "04098f3aec4c80",
                        DataWaznosci = DateTime.Now,
                        GlobalnyNumerJednostkiHandlowej = "3333",
                        NumerPartiiProdukcyjnej = "3333",
                        Cena = 5.60F,
                        Producent = "Mlekpol",
                    },
                    new Produkt()
                    {
                        ProduktId = 4,
                        Nazwa = "CocaCola",
                        RFIDTag = "0411903aec4c80",
                        DataWaznosci = DateTime.Now,
                        GlobalnyNumerJednostkiHandlowej = "4444",
                        NumerPartiiProdukcyjnej = "4444",
                        Cena = 5.00F,
                        Producent = "CocaCola Copmany",
                    },
                    new Produkt()
                    {
                        ProduktId = 5,
                        Nazwa = "Piwo Tyskie",
                        RFIDTag = "5555",
                        DataWaznosci = DateTime.Now,
                        GlobalnyNumerJednostkiHandlowej = "5555",
                        NumerPartiiProdukcyjnej = "5555",
                        Cena = 2.40F,
                        Producent = "Kompania Piwowarska",
                    }
                );

            modelBuilder.Entity<UpodobanieUzytkownika>().HasData(
                            new UpodobanieUzytkownika() { ProduktId = 1, UzytkownikId = "1" },
                            new UpodobanieUzytkownika() { ProduktId = 1, UzytkownikId = "2" },
                            new UpodobanieUzytkownika() { ProduktId = 1, UzytkownikId = "3" },
                            new UpodobanieUzytkownika() { ProduktId = 2, UzytkownikId = "1" },
                            new UpodobanieUzytkownika() { ProduktId = 2, UzytkownikId = "2" },
                            new UpodobanieUzytkownika() { ProduktId = 2, UzytkownikId = "3" },
                            new UpodobanieUzytkownika() { ProduktId = 3, UzytkownikId = "1" },
                            new UpodobanieUzytkownika() { ProduktId = 3, UzytkownikId = "2" },
                            new UpodobanieUzytkownika() { ProduktId = 3, UzytkownikId = "3" }
                );


        }

    }
}
