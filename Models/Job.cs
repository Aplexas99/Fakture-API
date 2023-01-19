using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaktureAPI.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public decimal CijenaDeviza { get; set; }
        [Required]
        public decimal CijenaKm { get; set; }

    }
}
