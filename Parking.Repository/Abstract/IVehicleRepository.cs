using Parking.Data;
using Parking.Models;
using Parking.Repository.Shared.Abstract;
using Parking.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Abstract
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAll(bool isAdmin, int userId);
    }
}
