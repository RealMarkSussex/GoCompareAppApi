using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVehicleService
    {
        public Task<string> GetVehicle(string base64, ComputerVisionSettings computerVisionSettings);
    }
}
