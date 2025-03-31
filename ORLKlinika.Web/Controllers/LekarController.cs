using App.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ORLKlinika.Web.Controllers
{
    public class LekarController : Controller
    {
        private readonly AppDbContext _context;

        public LekarController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lekari = _context.Lekari.ToList();
            return View(lekari);
        }
        [HttpGet]
        public IActionResult GetLekariByUsluga(int uslugaId)
        {
            var usluga = _context.Usluge.Find(uslugaId);
            if (usluga == null)
            {
                return NotFound();
            }

            var lekari = _context.Lekari
                .Where(l => l.Subspecijalizacija == usluga.Subspecijalizacija)
                .Select(l => new { l.Id, l.ImePrezime })
                .ToList();

            return Json(lekari);
        }

    }
}
