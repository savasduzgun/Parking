using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Repository.Abstract
{
    public interface IPolicyRepository : IRepository<Policy>
    {
        IEnumerable<Policy> GetAll(Guid vehicleId);
    }
}
