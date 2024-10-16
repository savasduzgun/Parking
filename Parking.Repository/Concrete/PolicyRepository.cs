using Parking.Data;
using Parking.Models;
using Parking.Repository.Abstract;
using Parking.Repository.Shared.Concrete;

namespace Parking.Repository.Concrete
{
    public class PolicyRepository : Repository<Policy>, IPolicyRepository
    {
        //  private readonly ApplicationDbContext _context;
        private readonly IVehiclePhotoRepository _vehiclePhotoRepository;
        public PolicyRepository(ApplicationDbContext context, IVehiclePhotoRepository vehiclePhotoRepository) : base(context)
        {
            //     _context = context;
            _vehiclePhotoRepository = vehiclePhotoRepository;
        }

        public IEnumerable<Policy> GetAll(Guid vehicleId)
        {
            // _context.Vehicles.FirstOrDefault(v => v.Guid == vehicleId).Id;
            ;
            return base.GetAll(p => p.VehicleId == _vehiclePhotoRepository.GetByGuid(vehicleId).Id);
        }
    }
}
