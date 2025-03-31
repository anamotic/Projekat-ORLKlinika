using App.Infrastructure;
using ORLKlinika.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ORLKlinika.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var korisnickoIme = HttpContext.Session.GetString("KorisnickoIme") ?? "Gost";
            ViewBag.KorisnickoIme = korisnickoIme;

            var danas = DateTime.Now.Date;
            var terminiZaDanas = _context.Termini
                .Include(t => t.Pacijent)  
                .Include(t => t.Lekar)     
                .Where(t => t.Datum.Date == danas)
                .ToList();

            return View(terminiZaDanas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
