using App.Infrastructure;
using App.ServiceLayer.DTOs;
using App.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ORLKlinika.Web.Controllers
{
    public class TerminController : Controller
    {
        private readonly ITerminService _terminService;
        private readonly AppDbContext _context;

        public TerminController(ITerminService terminService, AppDbContext context)
        {
            _terminService = terminService;
            _context = context;
        }
        public IActionResult Index()
        {
            var termini = _context.Termini
                .Include(t => t.Pacijent)
                .Include(t => t.Lekar)
                .Include(t => t.Usluga)
                .ToList();

            return View(termini);
        }

        [HttpGet]
        public IActionResult Create()
        {
            UcitajViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ZakaziTerminDto dto)
        {
            if (!ModelState.IsValid)
            {
                UcitajViewBag();
                return View(dto);
            }

            var istiDanTermini = _context.Termini
                .Where(t => t.LekarId == dto.LekarId && t.Datum.Date == dto.Datum.Date)
                .ToList();

            foreach (var t in istiDanTermini)
            {
                var razlika = Math.Abs((t.Datum - dto.Datum).TotalMinutes);
                if (razlika < 60)
                {
                    ModelState.AddModelError("", "Lekar već ima zakazan termin u ovom periodu. Mora postojati bar 1 sat razlike.");
                    UcitajViewBag();
                    return View(dto);
                }
            }

            _terminService.ZakaziTermin(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var termin = _context.Termini.Find(id);
            if (termin == null) return NotFound();

            var dto = new IzmeniTerminDto
            {
                Id = termin.Id,
                PacijentId = termin.PacijentId,
                UslugaId = termin.UslugaId,
                LekarId = termin.LekarId,
                Datum = termin.Datum
            };

            UcitajViewBag(id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(IzmeniTerminDto dto)
        {
            if (!ModelState.IsValid)
            {
                UcitajViewBag(dto.Id);
                return View(dto);
            }

            var istiDanTermini = _context.Termini
                .Where(t => t.LekarId == dto.LekarId &&
                            t.Datum.Date == dto.Datum.Date &&
                            t.Id != dto.Id)
                .ToList();

            foreach (var t in istiDanTermini)
            {
                var razlika = Math.Abs((t.Datum - dto.Datum).TotalMinutes);
                if (razlika < 60)
                {
                    ModelState.AddModelError("", "Lekar već ima zakazan termin u ovom vremenskom periodu. Potrebno je barem 1 sat razmaka.");
                    UcitajViewBag(dto.Id);
                    return View(dto);
                }
            }

            var termin = _context.Termini.Find(dto.Id);
            if (termin == null) return NotFound();

            termin.PacijentId = dto.PacijentId;
            termin.UslugaId = dto.UslugaId;
            termin.LekarId = dto.LekarId;
            termin.Datum = dto.Datum;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult ProsliTermini()
        {
            var prosliTermini = _context.Termini
                .Include(t => t.Pacijent)
                .Include(t => t.Usluga)
                .Where(t => t.Datum < DateTime.Now)
                .ToList();

            return View("Index", prosliTermini);
        }

        // Učitavanje podataka za dropdownove i zauzete termine
        private void UcitajViewBag(int? izuzmiTerminId = null)
        {
            ViewBag.Pacijenti = _context.Pacijenti.ToList();
            ViewBag.Lekari = _context.Lekari.ToList();
            ViewBag.Usluge = _context.Usluge.ToList();

            ViewBag.ZauzetiTermini = _context.Termini
                .Where(t => izuzmiTerminId == null || t.Id != izuzmiTerminId)
                .Select(t => new
                {
                    lekarId = t.LekarId,
                    datum = t.Datum
                })
                .ToList();
        }
    }
}
