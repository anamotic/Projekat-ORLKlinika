using System.ComponentModel.DataAnnotations;

namespace App.ServiceLayer.DTOs
{
    public class NoviPacijentDto
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [BirthDateValidation(ErrorMessage = "Datum rođenja mora biti pre današnjeg datuma.")]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public string Dijagnoza { get; set; }
        [Required]
        public string Alergije { get; set; }
        [Required]
        public string Terapije { get; set; }
        public class BirthDateValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime datum && datum >= DateTime.Today)
                {
                    return new ValidationResult("Datum rođenja mora biti pre današnjeg datuma.");
                }
                return ValidationResult.Success;
            }
        }
    }
}
