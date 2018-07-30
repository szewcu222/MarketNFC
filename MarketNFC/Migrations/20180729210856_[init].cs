using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketNFC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    DataRejestracji = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true)
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
                    Nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupa", x => x.GrupaId);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    ProduktId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: false),
                    RFIDTag = table.Column<string>(nullable: false),
                    DataWaznosci = table.Column<DateTime>(nullable: false),
                    Producent = table.Column<string>(nullable: true),
                    GlobalnyNumerJednostkiHandlowej = table.Column<int>(nullable: false),
                    NumerPartiiProdukcyjnej = table.Column<int>(nullable: false),
                    Cena = table.Column<float>(nullable: false)
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
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "Lodowka",
                columns: table => new
                {
                    LodowkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pojemnosc = table.Column<int>(nullable: false),
                    DataAktualizacji = table.Column<DateTime>(nullable: false),
                    GrupaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lodowka", x => x.LodowkaId);
                    table.ForeignKey(
                        name: "FK_Lodowka_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "GrupaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UzytkownikGrupa",
                columns: table => new
                {
                    UzytkownikId = table.Column<string>(nullable: false),
                    GrupaId = table.Column<int>(nullable: false)
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
                        name: "FK_UzytkownikGrupa_AspNetUsers_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpodobaniaUzytkownika",
                columns: table => new
                {
                    UzytkownikId = table.Column<string>(nullable: false),
                    ProduktId = table.Column<int>(nullable: false)
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
                        name: "FK_UpodobaniaUzytkownika_AspNetUsers_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StanLodowki",
                columns: table => new
                {
                    Ilosc = table.Column<int>(nullable: false),
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
                name: "Zamowienie",
                columns: table => new
                {
                    ZamowienieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataZamowienia = table.Column<DateTime>(nullable: false),
                    DataDostarczenia = table.Column<DateTime>(nullable: false),
                    TypZamowienia = table.Column<int>(nullable: false),
                    UzytkownikId = table.Column<string>(nullable: true),
                    LodowkaId = table.Column<int>(nullable: false)
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
                name: "ZamowienieProdukt",
                columns: table => new
                {
                    Ilosc = table.Column<int>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRejestracji", "Email", "EmailConfirmed", "Imie", "LockoutEnabled", "LockoutEnd", "Nazwisko", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "dee71fe8-917b-4bf4-ae91-c83149a76daf", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local), null, false, "Darek", false, null, "Malysz", null, null, null, null, false, null, false, null },
                    { "2", 0, "1b1e232c-e581-4cdc-ba5c-d9633866b0a8", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local), null, false, "Misia", false, null, "Mis", null, null, null, null, false, null, false, null },
                    { "3", 0, "9134dc56-a682-4751-a243-b675d2f0d613", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local), null, false, "Sebke", false, null, "Szczepankiewicz", null, null, null, null, false, null, false, null },
                    { "4", 0, "6af0bca6-74ea-4ae1-98b1-a8e3adaad0cd", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local), null, false, "MIchal", false, null, "Kozubek", null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Grupa",
                columns: new[] { "GrupaId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "debesciaki" },
                    { 2, "mlode_wilki" },
                    { 3, "banda chuja" }
                });

            migrationBuilder.InsertData(
                table: "Produkt",
                columns: new[] { "ProduktId", "Cena", "DataWaznosci", "GlobalnyNumerJednostkiHandlowej", "Nazwa", "NumerPartiiProdukcyjnej", "Producent", "RFIDTag" },
                values: new object[,]
                {
                    { 1, 5f, new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local), 1111, "SZAMPON", 1111, "SYOSS", "1111" },
                    { 2, 10f, new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local), 2222, "COLA", 2222, "SYOSS", "2222" },
                    { 3, 15f, new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local), 3333, "SZAMPON", 3333, "SYOSS", "3333" },
                    { 4, 20f, new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local), 4444, "PEPSI", 4444, "COLACOMP", "4444" },
                    { 5, 30f, new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local), 5555, "PAWO", 5555, "HARNAS", "5555" }
                });

            migrationBuilder.InsertData(
                table: "Lodowka",
                columns: new[] { "LodowkaId", "DataAktualizacji", "GrupaId", "Pojemnosc" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 29, 23, 8, 56, 409, DateTimeKind.Local), 1, 10 },
                    { 2, new DateTime(2018, 7, 29, 23, 8, 56, 410, DateTimeKind.Local), 2, 15 },
                    { 3, new DateTime(2018, 7, 29, 23, 8, 56, 410, DateTimeKind.Local), 3, 12 }
                });

            migrationBuilder.InsertData(
                table: "UpodobaniaUzytkownika",
                columns: new[] { "UzytkownikId", "ProduktId" },
                values: new object[,]
                {
                    { "1", 1 },
                    { "1", 2 },
                    { "1", 3 },
                    { "2", 1 },
                    { "2", 2 },
                    { "2", 3 },
                    { "3", 1 },
                    { "3", 2 },
                    { "3", 3 }
                });

            migrationBuilder.InsertData(
                table: "UzytkownikGrupa",
                columns: new[] { "UzytkownikId", "GrupaId" },
                values: new object[,]
                {
                    { "1", 1 },
                    { "3", 2 },
                    { "3", 3 }
                });

            migrationBuilder.InsertData(
                table: "StanLodowki",
                columns: new[] { "LodowkaId", "ProduktId", "Ilosc" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 1, 2, 3 },
                    { 1, 3, 3 },
                    { 2, 3, 3 },
                    { 2, 4, 3 },
                    { 2, 5, 3 },
                    { 3, 2, 3 },
                    { 3, 3, 3 },
                    { 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "ZamowienieId", "DataDostarczenia", "DataZamowienia", "LodowkaId", "TypZamowienia", "UzytkownikId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "2" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, "2" }
                });

            migrationBuilder.InsertData(
                table: "ZamowienieProdukt",
                columns: new[] { "ZamowienieId", "ProduktId", "Ilosc" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 2, 2 },
                    { 1, 3, 2 },
                    { 2, 1, 2 },
                    { 2, 2, 2 },
                    { 2, 3, 2 },
                    { 3, 3, 2 },
                    { 3, 4, 2 },
                    { 3, 5, 2 }
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
                name: "IX_Lodowka_GrupaId",
                table: "Lodowka",
                column: "GrupaId",
                unique: true,
                filter: "[GrupaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StanLodowki_ProduktId",
                table: "StanLodowki",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_UpodobaniaUzytkownika_ProduktId",
                table: "UpodobaniaUzytkownika",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_UzytkownikGrupa_GrupaId",
                table: "UzytkownikGrupa",
                column: "GrupaId");

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
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Lodowka");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Grupa");
        }
    }
}
