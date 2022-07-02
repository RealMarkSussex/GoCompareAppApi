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
                    DefaqtoRating = 5,
                    ClickoutUrl = "https://quote.admiral.com/AD/singleCar/car/googl"
                },
                new ResultInformation()
                {
                    PartnerName = "Churchill",
                    ImageUrl = "https://www.thetimes.co.uk/money-mentor/wp-content/uploads/2019/11/churchill-1573122746-747.png",
                    LegalAssistance = true,
                    BreakdownCover = true,
                    PersonalAccident = true,
                    CourtesyCar = true,
                    Price = 300.47,
                    Excess = 3000,
                    DefaqtoRating = 3,
                    ClickoutUrl = "https://www.churchill.com/car/quote/your-car"
                },
                new ResultInformation()
                {
                    PartnerName = "Tesco Bank",
                    ImageUrl = "https://www.verylvke.com/en/wp-content/uploads/sites/2/2020/01/tesco-bank-logo.png",
                    LegalAssistance = true,
                    BreakdownCover = true,
                    PersonalAccident = false,
                    CourtesyCar = false,
                    Price = 300.47,
                    Excess = 3000,
                    DefaqtoRating = 3,
                    ClickoutUrl = "https://generalins.tescobank.com/car/vehicle"
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
                $"CarUsage.{quoteInformation.VehicleDetails.CarUsage.ToFriendlyString()}",
                $"PeakTimes.{quoteInformation.VehicleDetails.PeakTimes.ToString().ToLower()}",
                $"PeakDriveRegularity.{quoteInformation.VehicleDetails.PeakDriveRegularity}"
            };

            foreach(var index in indexes)
            {
                resultInformation.Price += priceIncreases[index];
            }

            return resultInformation;
        }
    }
}
