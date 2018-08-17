using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketNFC.Migrations
{
    public partial class addFacebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "18c6b1cb-cf29-4e6d-a5e9-8596670dbb15", new DateTime(2018, 8, 17, 19, 44, 2, 297, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "7038fe8c-de66-4e5b-a8dc-9affa21f5e56", new DateTime(2018, 8, 17, 19, 44, 2, 297, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "98c583f0-2215-4e00-b0f6-289b99d1d909", new DateTime(2018, 8, 17, 19, 44, 2, 297, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "2036458d-6e64-4c1c-a21e-28573739f09f", new DateTime(2018, 8, 17, 19, 44, 2, 297, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 1,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 295, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 2,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 296, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 3,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 296, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 1,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 299, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 2,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 300, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 3,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 300, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 4,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 300, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 5,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 17, 19, 44, 2, 300, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
