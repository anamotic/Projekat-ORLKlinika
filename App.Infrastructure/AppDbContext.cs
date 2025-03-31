using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Lekar> Lekari { get; set; }
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<ZdravstveniKarton> ZdravstveniKartoni { get; set; }
        public DbSet<Termin> Termini { get; set; }
        public DbSet<MedicinskiTehnicar> MedicinskiTehnicari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacijent>()
                .HasOne(p => p.ZdravstveniKarton)
                .WithOne(k => k.Pacijent)
                .HasForeignKey<ZdravstveniKarton>(k => k.PacijentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacijent>()
                .HasMany(p => p.Termini)
                .WithOne(t => t.Pacijent)
                .HasForeignKey(t => t.PacijentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lekar>()
                .HasMany(l => l.Termini)
                .WithOne(t => t.Lekar)
                .HasForeignKey(t => t.LekarId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Usluga>()
                .HasMany(u => u.Termini)
                .WithOne(t => t.Usluga)
                .HasForeignKey(t => t.UslugaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lekar>().HasData(
                new Lekar { Id = 1, Ime = "Nikola", Prezime = "Jovanović", Subspecijalizacija = Subspecijalizacija.OtologijaINeurotologija },
                new Lekar { Id = 2, Ime = "Marija", Prezime = "Petrović", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Lekar { Id = 3, Ime = "Darko", Prezime = "Marković", Subspecijalizacija = Subspecijalizacija.Laringologija },
                new Lekar { Id = 4, Ime = "Ivan", Prezime = "Urošević", Subspecijalizacija = Subspecijalizacija.HirurgijaGlaveIVrata },
                new Lekar { Id = 5, Ime = "Zoran", Prezime = "Ivanović", Subspecijalizacija = Subspecijalizacija.EstetskaIRekonstruktivnaHirurgijaLica },
                new Lekar { Id = 6, Ime = "Lidija", Prezime = "Radosavljević", Subspecijalizacija = Subspecijalizacija.HirurgijaApneje },
                new Lekar { Id = 7, Ime = "Ivica", Prezime = "Radić", Subspecijalizacija = Subspecijalizacija.HirurgijaGlaveIVrata},
                new Lekar { Id = 8, Ime = "Jelena", Prezime = "Stanojević", Subspecijalizacija = Subspecijalizacija.PedijatrijskaORL}
            );

            modelBuilder.Entity<Pacijent>().HasData(
                new Pacijent { Id = 1, Ime = "Ana", Prezime = "Kovačević", DatumRodjenja = new DateTime(1990, 5, 15) },
                new Pacijent { Id = 2, Ime = "Marko", Prezime = "Stanić", DatumRodjenja = new DateTime(1985, 8, 20) }
            );

            modelBuilder.Entity<ZdravstveniKarton>().HasData(
                new ZdravstveniKarton { Id = 1, PacijentId = 1, Alergije = "Penicilin", Dijagnoza = "Nema", Terapije = "Nema" },
                new ZdravstveniKarton { Id = 2, PacijentId = 2, Alergije = "Nema", Dijagnoza = "Sinusitis", Terapije = "Nafazol kapi" }
            );

            modelBuilder.Entity<Usluga>().HasData(
                new Usluga { Id = 1, Naziv = "Audiološki pregled", Opis = "Provera sluha", Subspecijalizacija = Subspecijalizacija.OtologijaINeurotologija },
                new Usluga { Id = 2, Naziv = "Endoskopski pregled nosa", Opis = "Detaljan pregled nosa", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Usluga { Id = 3, Naziv = "Timpanometrija", Opis = "Provera funkcionalnosti srednjeg uha", Subspecijalizacija = Subspecijalizacija.OtologijaINeurotologija },
                new Usluga { Id = 4, Naziv = "Ispiranje uha", Opis = "Ispiranje uha", Subspecijalizacija = Subspecijalizacija.OtologijaINeurotologija },
                new Usluga { Id = 5, Naziv = "Vestibulometrija", Opis = "Ispitivanje funkcije akustičkog nerva", Subspecijalizacija = Subspecijalizacija.OtologijaINeurotologija },
                new Usluga { Id = 6, Naziv = "Tonsiloadenoidektomija", Opis = "Hirurško uklanjanje krajnika i adenoida", Subspecijalizacija = Subspecijalizacija.Laringologija },
                new Usluga { Id = 7, Naziv = "Septoplastika", Opis = "Hirurška korekcija devijacije nosne pregrade", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Usluga { Id = 8, Naziv = "FESS - Funkcionalna endoskopska hirurgija sinusa", Opis = "Minimalno invazivna operacija sinusa", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Usluga { Id = 9, Naziv = "Laringoskopija", Opis = "Pregled glasnih žica i larinksa", Subspecijalizacija = Subspecijalizacija.Laringologija },
                new Usluga { Id = 10, Naziv = "Polipektomija nosa", Opis = "Uklanjanje nosnih polipa", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Usluga { Id = 11, Naziv = "Pregled glasnica i vokalne terapije", Opis = "Dijagnostika i terapija poremećaja glasa", Subspecijalizacija = Subspecijalizacija.Laringologija },
                new Usluga { Id = 12, Naziv = "Pregled i lečenje hrkanja", Opis = "Dijagnostika i tretman problema hrkanja i apneje", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Usluga { Id = 13, Naziv = "Punkcija sinusa", Opis = "Evakuacija sekreta iz sinusa", Subspecijalizacija = Subspecijalizacija.Rinologija },
                new Usluga { Id = 14, Naziv = "Uklanjanje stranog tela iz uha, nosa ili grla", Opis = "Ekstrakcija stranih tela kod odraslih i dece", Subspecijalizacija = Subspecijalizacija.PedijatrijskaORL},
                new Usluga { Id = 15, Naziv = "Biopsija promene u usnoj duplji ili larinksu", Opis = "Uzimanje uzorka za histopatološku analizu", Subspecijalizacija = Subspecijalizacija.Laringologija },
                new Usluga { Id = 16, Naziv = "Lasersko uklanjanje promena u grlu", Opis = "Laserska terapija polipa, cisti ili papiloma", Subspecijalizacija = Subspecijalizacija.Laringologija },
                new Usluga { Id = 17, Naziv = "Otoskopski pregled", Opis = "Pregled spoljašnjeg i srednjeg uha", Subspecijalizacija = Subspecijalizacija.OtologijaINeurotologija },
                new Usluga { Id = 18, Naziv = "Allergološko testiranje na inhalacione alergene", Opis = "Testiranje alergijskih reakcija na aeroalergene", Subspecijalizacija = Subspecijalizacija.Rinologija }
            );

            modelBuilder.Entity<MedicinskiTehnicar>().HasData(
                new MedicinskiTehnicar { Id = 1, Ime = "Ivana", Prezime = "Babić", Username = "ib1234", Lozinka = "1234" }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
