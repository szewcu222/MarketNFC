using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketNFC.Migrations
{
    public partial class repairModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "372e5653-db9a-42fe-bee7-249dbdc8f57e", new DateTime(2018, 8, 17, 19, 3, 7, 388, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "c73b9b7c-d893-4943-912a-7b9312625ec3", new DateTime(2018, 8, 17, 19, 3, 7, 388, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "17f3e91a-3305-4a4c-be56-123f8561e0fb", new DateTime(2018, 8, 17, 19, 3, 7, 388, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "7375f74d-4f89-414e-8aee-3f82aabfb393", new DateTime(2018, 8, 17, 19, 3, 7, 388, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 1,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 385, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 2,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 387, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 3,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 387, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 1,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 392, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 2,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 392, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 3,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 392, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 4,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 392, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 5,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 3, 7, 392, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
