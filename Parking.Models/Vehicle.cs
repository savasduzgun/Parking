namespace Parking.Models
{
    public class Vehicle : BaseModel
    {
        public string LicensePlate { get; set; }
        public string Name { get; set; }
        public double Odometer { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
