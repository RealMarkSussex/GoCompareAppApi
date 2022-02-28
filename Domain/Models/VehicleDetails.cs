using Domain.Enums;

namespace Domain.Models
{
    public class VehicleDetails
    {
        public CarUsage CarUsage { get; set; }
        public ParkedLocations ParkedLocation { get; set; }
        public ParkedLocations OvernightParkedLocation { get; set; }
        private int _mileage;
        public int Mileage { get
            {
                return _mileage;
            }
            set
            {
                int roundedMileage = value % 1000 >= 500 ? value + 1000 - value % 1000 : value - value % 1000;
                if(roundedMileage == 0)
                {
                    _mileage = 1000;
                } 
                else
                {
                    _mileage = roundedMileage;
                }
            } 
        }
        public bool PeakTimes { get; set; }
        public int PeakDriveRegularity { get; set; }
    }
}
