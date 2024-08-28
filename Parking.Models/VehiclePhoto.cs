namespace Parking.Models
{
    public class VehiclePhoto : BaseModel
    {
        public string Path { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
