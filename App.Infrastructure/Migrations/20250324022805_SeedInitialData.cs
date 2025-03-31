using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lekari",
                columns: new[] { "Id", "Ime", "Prezime", "Subspecijalizacija" },
                values: new object[,]
                {
                    { 1, "Nikola", "Jovanović", 0 },
                    { 2, "Marija", "Petrović", 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicinskiTehnicari",
                columns: new[] { "Id", "Ime", "Lozinka", "Prezime", "Username" },
                values: new object[] { 1, "Ivana", "1234", "Babić", "ib1234" });

            migrationBuilder.InsertData(
                table: "Pacijenti",
                columns: new[] { "Id", "DatumRodjenja", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "Kovačević" },
                    { 2, new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko", "Stanić" }
                });

            migrationBuilder.InsertData(
                table: "Usluge",
                columns: new[] { "Id", "Naziv", "Opis", "Subspecijalizacija" },
                values: new object[,]
                {
                    { 1, "Audiološki pregled", "Provera sluha", 0 },
                    { 2, "Endoskopski pregled nosa", "Detaljan pregled nosa", 1 }
                });

            migrationBuilder.InsertData(
                table: "ZdravstveniKartoni",
                columns: new[] { "Id", "Alergije", "Dijagnoza", "PacijentId", "Terapije" },
                values: new object[,]
                {
                    { 1, "Penicilin", "Nema", 1, "Nema" },
                    { 2, "Nema", "Sinusitis", 2, "Nafazol kapi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicinskiTehnicari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZdravstveniKartoni",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZdravstveniKartoni",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
