using App.Domain;
using App.Infrastructure;
using App.ServiceLayer.DTOs;
using App.ServiceLayer.Interfaces;

namespace App.ServiceLayer.Services
{
    public class TerminService : ITerminService
    {
        private readonly AppDbContext _context;

        public TerminService(AppDbContext context)
        {
            _context = context;
        }

        public int ZakaziTermin(ZakaziTerminDto dto)
        {
            var usluga = _context.Usluge.Find(dto.UslugaId);
            if (usluga == null)
                throw new Exception("Usluga ne postoji.");

          /*  var lekar = _context.Lekari.Find(dto.LekarId);
            if (lekar == null || lekar.Subspecijalizacija != usluga.Subspecijalizacija)
                throw new Exception("Lekar nije specijalizovan za tu uslugu."); */

            var termin = new Termin
            {
                PacijentId = dto.PacijentId,
                LekarId = dto.LekarId,
                UslugaId = dto.UslugaId,
                Datum = dto.Datum
            };

            _context.Termini.Add(termin);
            _context.SaveChanges();

            return termin.Id;
        }
    }
}
