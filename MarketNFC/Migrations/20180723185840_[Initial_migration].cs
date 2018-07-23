using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarketNFC.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DataRejestracji = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Imie = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupa",
                columns: table => new
                {
                    GrupaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LodowkaId = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupa", x => x.GrupaId);
                });

            migrationBuilder.CreateTable(
                name: "Lodowka",
                columns: table => new
                {
                    LodowkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAktualizacji = table.Column<DateTime>(nullable: false),
                    GrupaId = table.Column<int>(nullable: false),
                    Pojemnosc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lodowka", x => x.LodowkaId);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    ProduktId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataWaznosci = table.Column<DateTime>(nullable: false),
                    Nazwa = table.Column<string>(nullable: false),
                    RFIDTag = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.ProduktId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UzytkownikGrupa",
                columns: table => new
                {
                    UzytkownikId = table.Column<int>(nullable: false),
                    GrupaId = table.Column<int>(nullable: false),
                    UzytkownikId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UzytkownikGrupa", x => new { x.UzytkownikId, x.GrupaId });
                    table.ForeignKey(
                        name: "FK_UzytkownikGrupa_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "GrupaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UzytkownikGrupa_AspNetUsers_UzytkownikId1",
                        column: x => x.UzytkownikId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    ZamowienieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDostarczenia = table.Column<DateTime>(nullable: false),
                    DataZamowienia = table.Column<DateTime>(nullable: false),
                    LodowkaId = table.Column<int>(nullable: false),
                    TypZamowienia = table.Column<int>(nullable: false),
                    UzytkownikId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.ZamowienieId);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Lodowka_LodowkaId",
                        column: x => x.LodowkaId,
                        principalTable: "Lodowka",
                        principalColumn: "LodowkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_AspNetUsers_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StanLodowki",
                columns: table => new
                {
                    LodowkaId = table.Column<int>(nullable: false),
                    ProduktId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StanLodowki", x => new { x.LodowkaId, x.ProduktId });
                    table.ForeignKey(
                        name: "FK_StanLodowki_Lodowka_LodowkaId",
                        column: x => x.LodowkaId,
                        principalTable: "Lodowka",
                        principalColumn: "LodowkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StanLodowki_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpodobaniaUzytkownika",
                columns: table => new
                {
                    UzytkownikId = table.Column<int>(nullable: false),
                    ProduktId = table.Column<int>(nullable: false),
                    UzytkownikId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpodobaniaUzytkownika", x => new { x.UzytkownikId, x.ProduktId });
                    table.ForeignKey(
                        name: "FK_UpodobaniaUzytkownika_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpodobaniaUzytkownika_AspNetUsers_UzytkownikId1",
                        column: x => x.UzytkownikId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZamowienieProdukt",
                columns: table => new
                {
                    ZamowienieId = table.Column<int>(nullable: false),
                    ProduktId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowienieProdukt", x => new { x.ZamowienieId, x.ProduktId });
                    table.ForeignKey(
                        name: "FK_ZamowienieProdukt_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZamowienieProdukt_Zamowienie_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienie",
                        principalColumn: "ZamowienieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StanLodowki_ProduktId",
                table: "StanLodowki",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_UpodobaniaUzytkownika_ProduktId",
                table: "UpodobaniaUzytkownika",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_UpodobaniaUzytkownika_UzytkownikId1",
                table: "UpodobaniaUzytkownika",
                column: "UzytkownikId1");

            migrationBuilder.CreateIndex(
                name: "IX_UzytkownikGrupa_GrupaId",
                table: "UzytkownikGrupa",
                column: "GrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_UzytkownikGrupa_UzytkownikId1",
                table: "UzytkownikGrupa",
                column: "UzytkownikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_LodowkaId",
                table: "Zamowienie",
                column: "LodowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_UzytkownikId",
                table: "Zamowienie",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_ZamowienieProdukt_ProduktId",
                table: "ZamowienieProdukt",
                column: "ProduktId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StanLodowki");

            migrationBuilder.DropTable(
                name: "UpodobaniaUzytkownika");

            migrationBuilder.DropTable(
                name: "UzytkownikGrupa");

            migrationBuilder.DropTable(
                name: "ZamowienieProdukt");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Grupa");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Lodowka");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
