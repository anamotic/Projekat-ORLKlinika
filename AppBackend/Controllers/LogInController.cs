using App.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ORLKlinika.Web.Controllers
{
    public class LogInController : Controller
    {
            private readonly AppDbContext _context;

            public LogInController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(string username, string lozinka)
            {
                var tehnicar = _context.MedicinskiTehnicari.FirstOrDefault(t => t.Username == username && t.Lozinka == lozinka);

                if (tehnicar == null)
                {
                    ViewBag.Poruka = "Pogrešno korisničko ime ili lozinka.";
                    return View();
                }

            HttpContext.Session.SetString("KorisnickoIme", $"{tehnicar.Ime} {tehnicar.Prezime}");
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
        }
    }

