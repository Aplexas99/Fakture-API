namespace FaktureAPI.DTOs
{
    public class PartnerForUpdateDTO
    {
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public string BrojPoste { get; set; }
        public string MB { get; set; }
        public string? Pbr { get; set; }
        public List<string>? Banka { get; set; }
        public string? Swift { get; set; }
        public bool Tip { get; set; }
        public string Drzava { get; set; }

    }
}
