namespace FaktureAPI.DTOs
{
    public class BillBodyForUpdateDTO
    {
            public string Opis { get; set; }
            public int Kolicina { get; set; }
            public decimal CijenaDeviza { get; set; }
            public decimal CijenaKm { get; set; }

            public decimal? Rabat { get; set; }

            public string? IznosRabata { get; set; }
            public decimal? PDV { get; set; }
            public string Vrijednost { get; set; }

    }
}
