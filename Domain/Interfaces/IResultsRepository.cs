using Domain.Models;

namespace Domain.Interfaces
{
    public interface IResultsRepository
    {
        public List<ResultsInformation> GetResultsList(QuoteInformation quoteInformation);
    }
}
