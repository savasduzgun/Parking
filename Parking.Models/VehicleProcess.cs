namespace Parking.Models
{
    public class VehicleProcess : BaseModel
    {
        public string? Description { get; set; }
        public double Odometer { get; set; }
        public double? Price { get; set; }
        public int VehicleProcessTypeId { get; set; }
        public virtual VehicleProcessType VehicleProcessType { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
