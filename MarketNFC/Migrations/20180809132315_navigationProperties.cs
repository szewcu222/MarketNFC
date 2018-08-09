using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketNFC.Migrations
{
    public partial class navigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "70737fc3-d8ea-4b12-a36a-5d21b7532533", new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "5e8a5639-8f90-4d59-b8f8-4ae29a20a456", new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "deaa8350-11cb-4edd-bf55-319a96f2e740", new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "b20aafa5-c36a-4b43-aba9-df8a5cb8ae90", new DateTime(2018, 8, 9, 15, 23, 15, 353, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 1,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 348, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 2,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 352, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 3,
                column: "DataAktualizacji",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 352, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 1,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 2,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 3,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 4,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 5,
                column: "DataWaznosci",
                value: new DateTime(2018, 8, 9, 15, 23, 15, 361, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "dee71fe8-917b-4bf4-ae91-c83149a76daf", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "1b1e232c-e581-4cdc-ba5c-d9633866b0a8", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "9134dc56-a682-4751-a243-b675d2f0d613", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DataRejestracji" },
                values: new object[] { "6af0bca6-74ea-4ae1-98b1-a8e3adaad0cd", new DateTime(2018, 7, 29, 23, 8, 56, 411, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 1,
                column: "DataAktualizacji",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 409, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 2,
                column: "DataAktualizacji",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 410, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Lodowka",
                keyColumn: "LodowkaId",
                keyValue: 3,
                column: "DataAktualizacji",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 410, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 1,
                column: "DataWaznosci",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 2,
                column: "DataWaznosci",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 3,
                column: "DataWaznosci",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 4,
                column: "DataWaznosci",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Produkt",
                keyColumn: "ProduktId",
                keyValue: 5,
                column: "DataWaznosci",
                value: new DateTime(2018, 7, 29, 23, 8, 56, 413, DateTimeKind.Local));
        }
    }
}
