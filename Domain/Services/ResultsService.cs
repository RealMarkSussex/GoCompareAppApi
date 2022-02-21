using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<ResultsInformation> GetResultsInformation(string regNo, string email)
        {
            var previousQuotes = quoteRepository.GetPreviousQuoteInformation(email);

            var vehicleInformation = vehicleRepository.GetVehicleInformation(regNo);

            var assummedQuote = quotesService.AssumeQuote(previousQuotes);

            // add vehicle data then to assummed quote
            return resultsRepository.GetResultsList(assummedQuote);
        }
    }
}
