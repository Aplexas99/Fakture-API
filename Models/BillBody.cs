using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaktureAPI.Models
{
    public class BillBody
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public decimal CijenaDeviza { get; set; }
        [Required]
        public decimal CijenaKm { get; set; }

        public decimal? Rabat { get; set; }

        public string? IznosRabata { get; set; }
        public decimal? PDV { get; set; }
        [Required]
        public string Vrijednost { get; set; }
        [ForeignKey(nameof(BillHeader))]
        public int BillHeaderId { get; set; }


    }
}
