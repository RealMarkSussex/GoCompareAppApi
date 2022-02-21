using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class QuoteService : IQuoteService
    {
        public QuoteInformation AssumeQuote(List<QuoteInformation> previousQuotes)
        {
            return new QuoteInformation();
        }
    }
}
