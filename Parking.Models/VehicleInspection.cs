namespace Parking.Models
{
    public class VehicleInspection : BaseModel
    {
        public string? Description { get; set; }
        public double Odometer { get; set; }
        public DateTime Validity { get; set; }
        public string? FilePath { get; set; } //RaporDosyası
        public bool IsPassed { get; set; } = true;
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
