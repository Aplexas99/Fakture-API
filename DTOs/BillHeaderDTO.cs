namespace FaktureAPI.DTOs
{
    public class BillHeaderDTO
    {
        public string BrojRacuna { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public DateTime DatumDokumenta { get; set; }
        public DateTime DatumDospijeca { get; set; }
        public string? Opis { get; set; }
        public string? Napomena { get; set; }
        public string MjestoIzdavanja { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string FiskalniBroj { get; set; }
        public int KupacId { get; set; }
        public decimal UkupanIznos { get; set; }
        public bool Status { get; set; }

    }
}
