namespace Parking.Models
{
    public class Vehicle : BaseModel
    {
        public string LicensePlate { get; set; }
        public string Name { get; set; }
        public double Odometer { get; set; }
    }
}
