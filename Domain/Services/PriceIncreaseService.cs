using Domain.Interfaces;

namespace Domain.Services
{
    public class PriceIncreaseService : IPriceIncreaseService
    {
        private readonly IPriceRepository priceRepository;

        public PriceIncreaseService(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }
        public Dictionary<string, double> GetPricesIncreases()
        {
            return priceRepository.GetPricesIncreases();
        }
    }
}
