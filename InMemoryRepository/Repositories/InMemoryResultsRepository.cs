using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryResultsRepository : IResultsRepository
    {
        private readonly IPriceRepository priceRepository;

        public InMemoryResultsRepository(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }
        public List<ResultInformation> GetResultsList(QuoteInformation quoteInformation)
        {
            var defaultResults = new List<ResultInformation>()
            {
                new ResultInformation()
                {
                    PartnerName = "Admiral",
                    ImageUrl = "https://cdn.freebiesupply.com/logos/thumbs/2x/admiral-16-logo.png",
                    LegalAssistance = false,
                    BreakdownCover = false,
                    PersonalAccident = false,
                    CourtesyCar = true,
                    Price = 500.47,
                    Excess = 400,
                    DefaqtoRating = 5
                },
                new ResultInformation()
                {
                    PartnerName = "CDL",
                    ImageUrl = "https://www.cdl.co.uk/assets/site-wide/optim/logo-cdl-blue.png",
                    LegalAssistance = true,
                    BreakdownCover = true,
                    PersonalAccident = false,
                    CourtesyCar = false,
                    Price = 300.47,
                    Excess = 3000,
                    DefaqtoRating = 3
                }
            };


            defaultResults = defaultResults.Select(x => IncreasePrice(x, quoteInformation)).ToList();

            return defaultResults;
        }

        private ResultInformation IncreasePrice(ResultInformation resultInformation, QuoteInformation quoteInformation)
        {
            var priceIncreases = priceRepository.GetPricesIncreases();

            var indexes = new List<string>()
            {
                $"{nameof(quoteInformation.VehicleDetails.Mileage)}.{quoteInformation.VehicleDetails.Mileage}",
                $"ParkedLocation.{quoteInformation.VehicleDetails.ParkedLocation.ToFriendlyString()}",
                $"CarUsage.{quoteInformation.VehicleDetails.CarUsage.ToFriendlyString()}"
            };

            foreach(var index in indexes)
            {
                resultInformation.Price += priceIncreases[index];
            }

            return resultInformation;
        }
    }
}
