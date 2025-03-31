using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DodateORLUsluge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lekari",
                columns: new[] { "Id", "Ime", "Prezime", "Subspecijalizacija" },
                values: new object[,]
                {
                    { 3, "Darko", "Marković", 2 },
                    { 4, "Ivan", "Urošević", 4 },
                    { 5, "Zoran", "Ivanović", 6 },
                    { 6, "Lidija", "Radosavljević", 5 },
                    { 7, "Ivica", "Radić", 4 },
                    { 8, "Jelena", "Stanojević", 3 }
                });

            migrationBuilder.InsertData(
                table: "Usluge",
                columns: new[] { "Id", "Naziv", "Opis", "Subspecijalizacija" },
                values: new object[,]
                {
                    { 3, "Timpanometrija", "Provera funkcionalnosti srednjeg uha", 0 },
                    { 4, "Ispiranje uha", "Ispiranje uha", 0 },
                    { 5, "Vestibulometrija", "Ispitivanje funkcije akustičkog nerva", 0 },
                    { 6, "Tonsiloadenoidektomija", "Hirurško uklanjanje krajnika i adenoida", 2 },
                    { 7, "Septoplastika", "Hirurška korekcija devijacije nosne pregrade", 1 },
                    { 8, "FESS - Funkcionalna endoskopska hirurgija sinusa", "Minimalno invazivna operacija sinusa", 1 },
                    { 9, "Laringoskopija", "Pregled glasnih žica i larinksa", 2 },
                    { 10, "Polipektomija nosa", "Uklanjanje nosnih polipa", 1 },
                    { 11, "Pregled glasnica i vokalne terapije", "Dijagnostika i terapija poremećaja glasa", 2 },
                    { 12, "Pregled i lečenje hrkanja", "Dijagnostika i tretman problema hrkanja i apneje", 1 },
                    { 13, "Punkcija sinusa", "Evakuacija sekreta iz sinusa", 1 },
                    { 14, "Uklanjanje stranog tela iz uha, nosa ili grla", "Ekstrakcija stranih tela kod odraslih i dece", 3 },
                    { 15, "Biopsija promene u usnoj duplji ili larinksu", "Uzimanje uzorka za histopatološku analizu", 2 },
                    { 16, "Lasersko uklanjanje promena u grlu", "Laserska terapija polipa, cisti ili papiloma", 2 },
                    { 17, "Otoskopski pregled", "Pregled spoljašnjeg i srednjeg uha", 0 },
                    { 18, "Allergološko testiranje na inhalacione alergene", "Testiranje alergijskih reakcija na aeroalergene", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lekari",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Usluge",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
