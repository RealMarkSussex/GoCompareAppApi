using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryResultsRepository : IResultsRepository
    {
        public List<ResultsInformation> GetResultsList(QuoteInformation quoteInformation)
        {
            return new List<ResultsInformation>();
        }
    }
}
