namespace App.Domain
{
    public class Lekar
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Subspecijalizacija Subspecijalizacija { get; set; }
        public List<Termin> Termini { get; set; }
        public string ImePrezime { get { return $"{Ime} {Prezime}"; } }
    }
}
