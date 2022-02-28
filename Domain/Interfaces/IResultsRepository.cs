using Domain.Models;

namespace Domain.Interfaces
{
    public interface IResultsRepository
    {
        public List<ResultInformation> GetResultsList(QuoteInformation quoteInformation);
    }
}
