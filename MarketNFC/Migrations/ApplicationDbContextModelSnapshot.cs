﻿// <auto-generated />
using System;
using MarketNFC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarketNFC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarketNFC.Models.Grupa", b =>
                {
                    b.Property<int>("GrupaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired();

                    b.HasKey("GrupaId");

                    b.ToTable("Grupa");

                    b.HasData(
                        new { GrupaId = 1, Nazwa = "debesciaki" },
                        new { GrupaId = 2, Nazwa = "mlode_wilki" },
                        new { GrupaId = 3, Nazwa = "banda chuja" }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.Lodowka", b =>
                {
                    b.Property<int>("LodowkaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAktualizacji");

                    b.Property<int?>("GrupaId");

                    b.Property<int>("Pojemnosc");

                    b.HasKey("LodowkaId");

                    b.HasIndex("GrupaId")
                        .IsUnique()
                        .HasFilter("[GrupaId] IS NOT NULL");

                    b.ToTable("Lodowka");

                    b.HasData(
                        new { LodowkaId = 1, DataAktualizacji = new DateTime(2018, 8, 9, 15, 23, 15, 348, DateTimeKind.Local), GrupaId = 1, Pojemnosc = 10 },
                        new { LodowkaId = 2, DataAktualizacji = new DateTime(2018, 8, 9, 15, 23, 15, 352, DateTimeKind.Local), GrupaId = 2, Pojemnosc = 15 },
                        new { LodowkaId = 3, DataAktualizacji = new DateTime(2018, 8, 9, 15, 23, 15, 352, DateTimeKind.Local), GrupaId = 3, Pojemnosc = 12 }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cena");

                    b.Property<DateTime>("DataWaznosci");

                    b.Property<int>("GlobalnyNumerJednostkiHandlowej");

                    b.Property<string>("Nazwa")
                        .IsRequired();

                    b.Property<int>("NumerPartiiProdukcyjnej");

                    b.Property<string>("Producent");

                    b.Property<string>("RFIDTag")
                        .IsRequired();

                    b.HasKey("ProduktId");

                    b.ToTable("Produkt");

                    b.HasData(
                        new { ProduktId = 1, Cena = 5f, DataWaznosci = new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local), GlobalnyNumerJednostkiHandlowej = 1111, Nazwa = "SZAMPON", NumerPartiiProdukcyjnej = 1111, Producent = "SYOSS", RFIDTag = "1111" },
                        new { ProduktId = 2, Cena = 10f, DataWaznosci = new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local), GlobalnyNumerJednostkiHandlowej = 2222, Nazwa = "COLA", NumerPartiiProdukcyjnej = 2222, Producent = "SYOSS", RFIDTag = "2222" },
                        new { ProduktId = 3, Cena = 15f, DataWaznosci = new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local), GlobalnyNumerJednostkiHandlowej = 3333, Nazwa = "SZAMPON", NumerPartiiProdukcyjnej = 3333, Producent = "SYOSS", RFIDTag = "3333" },
                        new { ProduktId = 4, Cena = 20f, DataWaznosci = new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local), GlobalnyNumerJednostkiHandlowej = 4444, Nazwa = "PEPSI", NumerPartiiProdukcyjnej = 4444, Producent = "COLACOMP", RFIDTag = "4444" },
                        new { ProduktId = 5, Cena = 30f, DataWaznosci = new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local), GlobalnyNumerJednostkiHandlowej = 5555, Nazwa = "PAWO", NumerPartiiProdukcyjnej = 5555, Producent = "HARNAS", RFIDTag = "5555" }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.StanLodowki", b =>
                {
                    b.Property<int>("LodowkaId");

                    b.Property<int>("ProduktId");

                    b.Property<int>("Ilosc");

                    b.HasKey("LodowkaId", "ProduktId");

                    b.HasIndex("ProduktId");

                    b.ToTable("StanLodowki");

                    b.HasData(
                        new { LodowkaId = 1, ProduktId = 1, Ilosc = 3 },
                        new { LodowkaId = 1, ProduktId = 2, Ilosc = 3 },
                        new { LodowkaId = 1, ProduktId = 3, Ilosc = 3 },
                        new { LodowkaId = 2, ProduktId = 3, Ilosc = 3 },
                        new { LodowkaId = 2, ProduktId = 4, Ilosc = 3 },
                        new { LodowkaId = 2, ProduktId = 5, Ilosc = 3 },
                        new { LodowkaId = 3, ProduktId = 2, Ilosc = 3 },
                        new { LodowkaId = 3, ProduktId = 3, Ilosc = 3 },
                        new { LodowkaId = 3, ProduktId = 4, Ilosc = 3 }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.UpodobanieUzytkownika", b =>
                {
                    b.Property<string>("UzytkownikId");

                    b.Property<int>("ProduktId");

                    b.HasKey("UzytkownikId", "ProduktId");

                    b.HasIndex("ProduktId");

                    b.ToTable("UpodobaniaUzytkownika");

                    b.HasData(
                        new { UzytkownikId = "1", ProduktId = 1 },
                        new { UzytkownikId = "2", ProduktId = 1 },
                        new { UzytkownikId = "3", ProduktId = 1 },
                        new { UzytkownikId = "1", ProduktId = 2 },
                        new { UzytkownikId = "2", ProduktId = 2 },
                        new { UzytkownikId = "3", ProduktId = 2 },
                        new { UzytkownikId = "1", ProduktId = 3 },
                        new { UzytkownikId = "2", ProduktId = 3 },
                        new { UzytkownikId = "3", ProduktId = 3 }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.Uzytkownik", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DataRejestracji");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Imie");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nazwisko");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "1", AccessFailedCount = 0, ConcurrencyStamp = "70737fc3-d8ea-4b12-a36a-5d21b7532533", DataRejestracji = new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local), EmailConfirmed = false, Imie = "Darek", LockoutEnabled = false, Nazwisko = "Malysz", PhoneNumberConfirmed = false, TwoFactorEnabled = false },
                        new { Id = "2", AccessFailedCount = 0, ConcurrencyStamp = "5e8a5639-8f90-4d59-b8f8-4ae29a20a456", DataRejestracji = new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local), EmailConfirmed = false, Imie = "Misia", LockoutEnabled = false, Nazwisko = "Mis", PhoneNumberConfirmed = false, TwoFactorEnabled = false },
                        new { Id = "3", AccessFailedCount = 0, ConcurrencyStamp = "deaa8350-11cb-4edd-bf55-319a96f2e740", DataRejestracji = new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local), EmailConfirmed = false, Imie = "Sebke", LockoutEnabled = false, Nazwisko = "Szczepankiewicz", PhoneNumberConfirmed = false, TwoFactorEnabled = false },
                        new { Id = "4", AccessFailedCount = 0, ConcurrencyStamp = "b20aafa5-c36a-4b43-aba9-df8a5cb8ae90", DataRejestracji = new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local), EmailConfirmed = false, Imie = "MIchal", LockoutEnabled = false, Nazwisko = "Kozubek", PhoneNumberConfirmed = false, TwoFactorEnabled = false }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.UzytkownikGrupa", b =>
                {
                    b.Property<string>("UzytkownikId");

                    b.Property<int>("GrupaId");

                    b.HasKey("UzytkownikId", "GrupaId");

                    b.HasIndex("GrupaId");

                    b.ToTable("UzytkownikGrupa");

                    b.HasData(
                        new { UzytkownikId = "1", GrupaId = 1 },
                        new { UzytkownikId = "3", GrupaId = 2 },
                        new { UzytkownikId = "3", GrupaId = 3 }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.Zamowienie", b =>
                {
                    b.Property<int>("ZamowienieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDostarczenia");

                    b.Property<DateTime>("DataZamowienia");

                    b.Property<int>("LodowkaId");

                    b.Property<int>("TypZamowienia");

                    b.Property<string>("UzytkownikId");

                    b.HasKey("ZamowienieId");

                    b.HasIndex("LodowkaId");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Zamowienie");

                    b.HasData(
                        new { ZamowienieId = 1, DataDostarczenia = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DataZamowienia = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LodowkaId = 1, TypZamowienia = 0, UzytkownikId = "1" },
                        new { ZamowienieId = 2, DataDostarczenia = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DataZamowienia = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LodowkaId = 1, TypZamowienia = 0, UzytkownikId = "2" },
                        new { ZamowienieId = 3, DataDostarczenia = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DataZamowienia = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LodowkaId = 2, TypZamowienia = 0, UzytkownikId = "2" }
                    );
                });

            modelBuilder.Entity("MarketNFC.Models.ZamowienieProdukt", b =>
                {
                    b.Property<int>("ZamowienieId");

                    b.Property<int>("ProduktId");

                    b.Property<int>("Ilosc");

                    b.HasKey("ZamowienieId", "ProduktId");

                    b.HasIndex("ProduktId");

                    b.ToTable("ZamowienieProdukt");

                    b.HasData(
                        new { ZamowienieId = 1, ProduktId = 1, Ilosc = 2 },
                        new { ZamowienieId = 1, ProduktId = 2, Ilosc = 2 },
                        new { ZamowienieId = 1, ProduktId = 3, Ilosc = 2 },
                        new { ZamowienieId = 2, ProduktId = 1, Ilosc = 2 },
                        new { ZamowienieId = 2, ProduktId = 2, Ilosc = 2 },
                        new { ZamowienieId = 2, ProduktId = 3, Ilosc = 2 },
                        new { ZamowienieId = 3, ProduktId = 3, Ilosc = 2 },
                        new { ZamowienieId = 3, ProduktId = 4, Ilosc = 2 },
                        new { ZamowienieId = 3, ProduktId = 5, Ilosc = 2 }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MarketNFC.Models.Lodowka", b =>
                {
                    b.HasOne("MarketNFC.Models.Grupa", "Grupa")
                        .WithOne("Lodowka")
                        .HasForeignKey("MarketNFC.Models.Lodowka", "GrupaId");
                });

            modelBuilder.Entity("MarketNFC.Models.StanLodowki", b =>
                {
                    b.HasOne("MarketNFC.Models.Lodowka", "Lodowka")
                        .WithMany("StanLodowki")
                        .HasForeignKey("LodowkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarketNFC.Models.Produkt", "Produkt")
                        .WithMany("StanLodowki")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarketNFC.Models.UpodobanieUzytkownika", b =>
                {
                    b.HasOne("MarketNFC.Models.Produkt", "Produkt")
                        .WithMany("UpodobanieUzytkownikow")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarketNFC.Models.Uzytkownik", "Uzytkownik")
                        .WithMany("UpodobaniaUzytkownika")
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarketNFC.Models.UzytkownikGrupa", b =>
                {
                    b.HasOne("MarketNFC.Models.Grupa", "Grupa")
                        .WithMany("UzytkownikGrupy")
                        .HasForeignKey("GrupaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarketNFC.Models.Uzytkownik", "Uzytkownik")
                        .WithMany("UzytkownikGrupy")
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarketNFC.Models.Zamowienie", b =>
                {
                    b.HasOne("MarketNFC.Models.Lodowka", "Lodowka")
                        .WithMany("Zamowienia")
                        .HasForeignKey("LodowkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarketNFC.Models.Uzytkownik", "Uzytkownik")
                        .WithMany("Zamowienia")
                        .HasForeignKey("UzytkownikId");
                });

            modelBuilder.Entity("MarketNFC.Models.ZamowienieProdukt", b =>
                {
                    b.HasOne("MarketNFC.Models.Produkt", "Produkt")
                        .WithMany("ZamowienieProdukty")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarketNFC.Models.Zamowienie", "Zamowienie")
                        .WithMany("ZamowienieProdukty")
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MarketNFC.Models.Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MarketNFC.Models.Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarketNFC.Models.Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MarketNFC.Models.Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
