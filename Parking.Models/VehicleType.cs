﻿namespace Parking.Models
{
    public class VehicleType : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
