﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarketNFC.Models;

namespace MarketNFC.Data
{
    public class ApplicationDbContext : IdentityDbContext<Uzytkownik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Lodowka> Lodowki { get; set; }
        public DbSet<StanLodowki> StanyLodowek { get; set; }
        public DbSet<UpodobaniaUzytkownika> UpodobaniaUzytkownikow { get; set; }
        public DbSet<UzytkownikGrupa> UzytkownicyGrupy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<ZamowienieProdukt> ZamowieniaProdukty { get; set; }

        public static ApplicationDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer(connectionString, providerOptions=>providerOptions.CommandTimeout(60));
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
