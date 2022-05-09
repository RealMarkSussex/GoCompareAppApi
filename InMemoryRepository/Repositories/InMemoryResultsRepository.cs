using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryResultsRepository : IResultsRepository
    {
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

            if(quoteInformation.CoverDetails.VoluntaryExcess == 250)
            {
                defaultResults.Select(x => IncreasePrice(30, x));
            } 
            else if (quoteInformation.CoverDetails.VoluntaryExcess == 100)
            {
                defaultResults.Select(x => IncreasePrice(-20, x));
            }

            return defaultResults;
        }

        private ResultInformation IncreasePrice(int priceIncrease, ResultInformation resultInformation)
        {
            resultInformation.Price += priceIncrease;
            return resultInformation;
        }
    }
}
