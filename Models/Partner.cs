using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaktureAPI.Models
{
    public class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [MaxLength(3)]
        public List<string>? Banka { get; set; }
 
        public string? Swift { get; set; }
        [Required]
        public bool Tip { get; set; }
        [Required]
        public string Drzava { get; set; }


    }
}
