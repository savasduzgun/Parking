using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Repository.Abstract
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAll(bool isAdmin, int userId);
        void DeleteVehiclesByUserId(int userId);
    }
}
