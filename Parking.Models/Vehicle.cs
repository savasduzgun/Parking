﻿namespace Parking.Models
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
        public virtual ICollection<VehiclePhoto> VehiclePhotos { get; set; } = new List<VehiclePhoto>();
        public virtual ICollection<VehicleProcess> VehicleProcesses { get; set; } = new List<VehicleProcess>();
        public virtual ICollection<VehicleInspection> VehicleInspections { get; set;} = new List<VehicleInspection>();
        public virtual ICollection<Policy> VehiclePolicies { get; set; } = new List<Policy>();
    }
}
