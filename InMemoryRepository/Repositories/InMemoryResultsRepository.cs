using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryResultsRepository : IResultsRepository
    {
        public List<ResultInformation> GetResultsList(QuoteInformation quoteInformation)
        {
            return new List<ResultInformation>()
            {
                new ResultInformation()
                {
                    PartnerName = "Admiral"
                },
                new ResultInformation()
                {
                    PartnerName = "CDL"
                }
            };
        }
    }
}
