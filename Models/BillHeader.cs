using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaktureAPI.Models
{
    public class BillHeader
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string BrojRacuna { get; set; }
        [Required]
        public DateTime DatumIsporuke { get; set; }
        [Required]
        public DateTime DatumDokumenta { get; set; }
        [Required]
        public DateTime DatumDospijeca { get; set; }

        public string? Opis { get; set; }
        public string? Napomena { get; set; }
        [Required]
        public string MjestoIzdavanja { get; set; }
        [Required]
        public DateTime DatumIzdavanja { get; set; }
        public string FiskalniBroj { get; set; }
        [ForeignKey(nameof(Partner))]
        public int KupacId { get; set; }
        [Required]
        public decimal UkupanIznos { get; set; }
        public bool Status { get; set; }
        

    }
}
