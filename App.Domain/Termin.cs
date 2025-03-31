namespace App.Domain
{
    public class Termin
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
        public int LekarId { get; set; }
        public Lekar Lekar { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
    }
}