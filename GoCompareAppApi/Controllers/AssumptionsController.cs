using Domain.Interfaces;
using Domain.Models;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssumptionsController
    {
        private readonly IResultsService resultsService;

        public AssumptionsController(IResultsService resultsService)
        {
            this.resultsService = resultsService;
        }

        [HttpPost(Name = "NewAssumption")]
        public async Task<ResultsResponseData> AssumptionChange(QuoteInformation quoteInformation)
        {
            var results = resultsService.GetResultsInformation(quoteInformation);

            return new ResultsResponseData()
            {
                Results = results
            };
        }
    }
}
