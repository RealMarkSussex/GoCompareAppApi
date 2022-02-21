using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryQuoteRepository : IQuoteRepository
    {
        public List<QuoteInformation> GetPreviousQuoteInformation(string email)
        {
            return new List<QuoteInformation>();
        }
    }
}
