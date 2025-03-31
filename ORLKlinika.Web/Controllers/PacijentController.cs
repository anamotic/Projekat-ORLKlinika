using App.Domain;
using App.Infrastructure;
using App.ServiceLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ORLKlinika.Web.Controllers
{
    public class PacijentController : Controller
    {
        private readonly AppDbContext _context;

        public PacijentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pacijenti = _context.Pacijenti.ToList();
            return View(pacijenti);
        }

        public IActionResult Karton(int id)
        {
            var pacijent = _context.Pacijenti
                .Include(p => p.ZdravstveniKarton)
                .FirstOrDefault(p => p.Id == id);

            if (pacijent == null || pacijent.ZdravstveniKarton == null)
                return NotFound();

            return View(pacijent);
        }
        [HttpPost]
        public IActionResult IzmeniKarton(int Id, string Ime, string Prezime, DateTime DatumRodjenja, string Dijagnoza, string Terapije)
        {
            var pacijent = _context.Pacijenti
                .Include(p => p.ZdravstveniKarton)
                .FirstOrDefault(p => p.Id == Id);

            if (pacijent == null || pacijent.ZdravstveniKarton == null)
                return NotFound();

            pacijent.Ime = Ime;
            pacijent.Prezime = Prezime;
            pacijent.DatumRodjenja = DatumRodjenja;
            pacijent.ZdravstveniKarton.Dijagnoza = Dijagnoza;
            pacijent.ZdravstveniKarton.Terapije = Terapije;

            _context.SaveChanges();

            return RedirectToAction("Index", "Pacijent");
        }
        [HttpGet]
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(NoviPacijentDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var pacijent = new Pacijent
            {
                Ime = dto.Ime,
                Prezime = dto.Prezime,
                DatumRodjenja = dto.DatumRodjenja,
                ZdravstveniKarton = new ZdravstveniKarton
                {
                    Dijagnoza = dto.Dijagnoza,
                    Alergije = dto.Alergije,
                    Terapije = dto.Terapije
                }
            };

            _context.Pacijenti.Add(pacijent);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var pacijent = _context.Pacijenti.Include(p => p.ZdravstveniKarton).FirstOrDefault(p => p.Id == id);
            if (pacijent == null)
                return NotFound();

            if (pacijent.ZdravstveniKarton != null)
                _context.ZdravstveniKartoni.Remove(pacijent.ZdravstveniKarton);

            _context.Pacijenti.Remove(pacijent);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pacijent = _context.Pacijenti
                .Include(p => p.ZdravstveniKarton)
                .FirstOrDefault(p => p.Id == id);

            if (pacijent == null)
                return NotFound();

            var dto = new IzmeniPacijentaDto
            {
                Id = pacijent.Id,
                Ime = pacijent.Ime,
                Prezime = pacijent.Prezime,
                DatumRodjenja = pacijent.DatumRodjenja,
                Dijagnoza = pacijent.ZdravstveniKarton?.Dijagnoza,
                Alergije = pacijent.ZdravstveniKarton?.Alergije,
                Terapije = pacijent.ZdravstveniKarton?.Terapije
            };

            return View(dto); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IzmeniPacijentaDto dto)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState nije validan!");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(dto);
            }

            var postoji = _context.Pacijenti
                .Include(p => p.ZdravstveniKarton)
                .FirstOrDefault(p => p.Id == dto.Id);

            if (postoji == null)
                return NotFound();

            postoji.Ime = dto.Ime;
            postoji.Prezime = dto.Prezime;
            postoji.DatumRodjenja = dto.DatumRodjenja;

            if (postoji.ZdravstveniKarton != null)
            {
                postoji.ZdravstveniKarton.Dijagnoza = dto.Dijagnoza;
                postoji.ZdravstveniKarton.Terapije = dto.Terapije;
                postoji.ZdravstveniKarton.Alergije = dto.Alergije;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
