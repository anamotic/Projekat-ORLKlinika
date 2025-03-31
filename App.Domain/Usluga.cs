namespace App.Domain
{
    public class Usluga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public Subspecijalizacija Subspecijalizacija { get; set; }
        public List<Termin> Termini { get; set; }
    }
}
