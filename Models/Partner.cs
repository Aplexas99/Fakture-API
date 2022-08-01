using System.ComponentModel.DataAnnotations;

namespace FaktureAPI.Models
{
    public class Partner
    {

        public int Id { get; set; }
        [Required]
        public string Naziv { get; set;}
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Mjesto { get; set; }

        [Required]
        public string BrojPoste { get; set; }

        [Required]
        public string MB { get; set; }
        public string? Pbr { get; set; }

        public List<string>? Banka { get; set; }
 
        public string? Swift { get; set; }
        [Required]
        public bool Tip { get; set; }
        [Required]
        public string Drzava { get; set; }


    }
}
