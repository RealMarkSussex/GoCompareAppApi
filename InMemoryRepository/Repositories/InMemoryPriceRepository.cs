using Domain.Interfaces;

namespace InMemoryRepository.Repositories
{
    public class InMemoryPriceRepository : IPriceRepository
    {
        public Dictionary<string, double> GetPricesIncreases()
        {
            var result = new Dictionary<string, double>();

            result.Add("CarUsage.SocialOnly", 0);
            result.Add("CarUsage.BusinessUse", 5.10);
            result.Add("CarUsage.SocialAndCommuting", 10.34);

            result.Add("Mileage.1000", 0);
            result.Add("Mileage.2000", 1.13);
            result.Add("Mileage.3000", 2.90);
            result.Add("Mileage.4000", 3.56);
            result.Add("Mileage.5000", 4.15);
            result.Add("Mileage.6000", 5.83);
            result.Add("Mileage.7000", 6.43);

            result.Add("ParkedLocation.OnADriveway", 0);
            result.Add("ParkedLocation.OnTheRoadAtHome", 5.00);
            result.Add("ParkedLocation.InAWorkCarPark", 10.70);
            result.Add("ParkedLocation.Other", 10.31);

            return result;
        }
    }
}
