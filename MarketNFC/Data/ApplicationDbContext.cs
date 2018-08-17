using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarketNFC.Models;
using Microsoft.Extensions.Configuration;
using MarketNFC.Extensions;

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
        public DbSet<UpodobanieUzytkownika> UpodobaniaUzytkownikow { get; set; }
        public DbSet<UzytkownikGrupa> UzytkownicyGrupy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<ZamowienieProdukt> ZamowieniaProdukty { get; set; }

        const string conString = "Server=(localdb)\\mssqllocaldb;"
           + "Database=aspnet-MarketNFC-D8B02893-7B80-4147-93E2-9C1BF8DB927;"
           + "Trusted_Connection=True;MultipleActiveResultSets=true";

        public static ApplicationDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder
                .UseSqlServer(conString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //StanLodowki
            builder.Entity<StanLodowki>()
                .HasKey(sl => new { sl.LodowkaId, sl.ProduktId });

            builder.Entity<StanLodowki>()
                .HasOne(sl => sl.Lodowka)
                .WithMany("StanLodowki")
                .HasForeignKey(sl => sl.LodowkaId);

            builder.Entity<StanLodowki>()
                .HasOne(sl => sl.Produkt)
                .WithMany("StanLodowki")
                .HasForeignKey(sl => sl.ProduktId);

            //UpodobaniaUzytkownika
            builder.Entity<UpodobanieUzytkownika>()
                .HasKey(x => new { x.UzytkownikId, x.ProduktId });

            builder.Entity<UpodobanieUzytkownika>()
               .HasOne(uu => uu.Uzytkownik)
               .WithMany("UpodobaniaUzytkownika")
               .HasForeignKey(uu => uu.UzytkownikId);

            builder.Entity<UpodobanieUzytkownika>()
                .HasOne(uu => uu.Produkt)
                .WithMany("UpodobanieUzytkownikow")
                .HasForeignKey(uu => uu.ProduktId);

            //UzytkownikGrupa
            builder.Entity<UzytkownikGrupa>()
                .HasKey(x => new { x.UzytkownikId, x.GrupaId });

            builder.Entity<UzytkownikGrupa>()
               .HasOne(ug => ug.Uzytkownik)
               .WithMany("UzytkownikGrupy")
               .HasForeignKey(ug => ug.UzytkownikId);

            builder.Entity<UzytkownikGrupa>()
                .HasOne(ug => ug.Grupa)
                .WithMany("UzytkownikGrupy")
                .HasForeignKey(ug => ug.GrupaId);

            //ZamowienieProdukt
            builder.Entity<ZamowienieProdukt>()
                .HasKey(x => new { x.ZamowienieId, x.ProduktId });

            builder.Entity<ZamowienieProdukt>()
                .HasOne(zp => zp.Zamowienie)
                .WithMany("ZamowienieProdukty")
                .HasForeignKey(zp => zp.ZamowienieId);

            builder.Entity<ZamowienieProdukt>()
                .HasOne(zp => zp.Produkt)
                .WithMany("ZamowienieProdukty")
                .HasForeignKey(zp => zp.ProduktId);

            builder.Seed();
        }
    }
}