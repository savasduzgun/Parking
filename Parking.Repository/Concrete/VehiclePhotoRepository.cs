using Parking.Data;
using Parking.Models;
using Parking.Repository.Abstract;
using Parking.Repository.Shared.Concrete;

namespace Parking.Repository.Concrete
{
    public class VehiclePhotoRepository : Repository<VehiclePhoto>, IVehiclePhotoRepository
    {
        private readonly IVehicleRepository _vehicleRepository;


        public VehiclePhotoRepository(ApplicationDbContext context, IVehicleRepository vehicleRepository) : base(context)
        {
            _vehicleRepository = vehicleRepository;

        }

        public IEnumerable<VehiclePhoto> GetAll(Guid vehicleGuid)
        {
            // _context.Vehicles.FirstOrDefault(v => v.Guid == vehicleGuid);
            int vehicleId = _vehicleRepository.GetByGuid(vehicleGuid).Id;

            return base.GetAll(vp => vp.VehicleId == vehicleId);

        }
    }
}
