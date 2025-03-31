namespace App.ServiceLayer.DTOs
{
    public class ZakaziTerminDto
    {
        public int PacijentId { get; set; }
        public int UslugaId { get; set; }
        public int LekarId { get; set; }
        public DateTime Datum { get; set; }
    }
}
