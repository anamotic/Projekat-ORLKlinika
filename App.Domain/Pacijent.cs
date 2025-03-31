namespace App.Domain
{
    public class Pacijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public ZdravstveniKarton ZdravstveniKarton { get; set; }
        public List<Termin> Termini { get; set; }
        public string ImePrezime { get { return $"{Ime} {Prezime}"; } }
    }
}
