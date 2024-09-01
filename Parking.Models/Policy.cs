namespace Parking.Models
{
    public class Policy : BaseModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; } //SigortaFirması
        public string? FilePath { get; set; } //PoliçeDosyası
        public DateTime Validity { get; set; } //GeçerlilikTarihi
        public int PolicyTypeId { get; set; }
        public virtual PolicyType PolicyType { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
