using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Repository.Abstract
{
    public interface IVehiclePhotoRepository : IRepository<VehiclePhoto>
    {
        IEnumerable<VehiclePhoto> GetAll(Guid vehicleGuid);
    }
}
