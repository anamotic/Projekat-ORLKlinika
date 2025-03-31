namespace App.Domain
{
    public class ZdravstveniKarton
    {
        public int Id { get; set; }
        public string Alergije { get; set; }
        public string Dijagnoza { get; set; }
        public string Terapije { get; set; }
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

    }
}
