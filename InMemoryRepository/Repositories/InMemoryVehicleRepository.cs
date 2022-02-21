using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        public VehicleInformation GetVehicleInformation(string regNo)
        {
            return new VehicleInformation();
        }
    }
}
