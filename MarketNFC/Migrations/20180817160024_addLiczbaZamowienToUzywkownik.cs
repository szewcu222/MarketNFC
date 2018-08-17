using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketNFC.Migrations
{
    public partial class addLiczbaZamowienToUzywkownik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "4a7121de-b67f-4ad6-b6e7-c533f325386f", new DateTime(2018, 8, 17, 18, 0, 23, 763, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "ff5e21b0-f9c9-4a30-adf7-2e0a826cb2f6", new DateTime(2018, 8, 17, 18, 0, 23, 763, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "a0e77578-c003-4f40-9865-f2ae61b9cec7", new DateTime(2018, 8, 17, 18, 0, 23, 763, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "351d1691-1d37-424b-8848-cba881f41a1c", new DateTime(2018, 8, 17, 18, 0, 23, 763, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 1,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 760, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 2,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 762, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 3,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 762, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 1,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 765, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 2,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 765, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 3,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 765, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 4,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 765, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 5,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 18, 0, 23, 765, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "b943dd6a-d628-4926-945c-22b9c5c0c141", new DateTime(2018, 8, 9, 20, 9, 3, 272, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "70593a8e-be3b-4663-920c-13ca3828319a", new DateTime(2018, 8, 9, 20, 9, 3, 272, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "ce3a9bfa-9488-4a7b-acc3-f4de18f086cd", new DateTime(2018, 8, 9, 20, 9, 3, 272, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "613717e8-b3a3-4f2d-9eaf-45e93e766f0b", new DateTime(2018, 8, 9, 20, 9, 3, 272, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 1,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 270, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 2,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 3,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 1,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 275, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 2,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 275, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 3,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 275, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 4,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 275, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 5,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 20, 9, 3, 275, DateTimeKind.Local));
        }
    }
}
