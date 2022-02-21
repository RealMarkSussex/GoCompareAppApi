using Domain.Enums;

namespace Domain.Models
{
    public class VehicleDetails
    {
        public CarUsage CarUsage { get; set; }
        public ParkedLocations parkedLocation { get; set; }
        public int Mileage { get; set; }
        public bool PeakTimes { get; set; }
        public int PeakDriveRegularity { get; set; }
    }
}
