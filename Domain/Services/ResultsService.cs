using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class ResultsService : IResultsService
    {
        private readonly IQuoteRepository quoteRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IQuoteService quotesService;
        private readonly IResultsRepository resultsRepository;

        public ResultsService(IQuoteRepository quoteRepository, IVehicleRepository vehicleRepository, IQuoteService quotesService, IResultsRepository resultsRepository)
        {
            this.quoteRepository = quoteRepository;
            this.vehicleRepository = vehicleRepository;
            this.quotesService = quotesService;
            this.resultsRepository = resultsRepository;
        }
        public List<ResultInformation> GetResultsInformation(string regNo, string email)
        {
            var previousQuotes = quoteRepository.GetPreviousQuoteInformation(email);

            var vehicleInformation = vehicleRepository.GetVehicleInformation(regNo);

            var assummedQuote = quotesService.AssumeQuote(previousQuotes);

            // add vehicle data then to assummed quote
            return resultsRepository.GetResultsList(assummedQuote);
        }

        public List<ResultInformation> GetResultsInformation(UserInformation userInformation)
        {
            var vehicleInformation = vehicleRepository.GetVehicleInformation(userInformation.RegNo);

            var assummedQuote = quotesService.AssumeQuote(userInformation);

            // add vehicle data then to assummed quote
            return resultsRepository.GetResultsList(assummedQuote);
        }

        public List<ResultInformation> GetResultsInformation(QuoteInformation quoteInformation)
        {
            return resultsRepository.GetResultsList(quoteInformation);
        }
    }
}
