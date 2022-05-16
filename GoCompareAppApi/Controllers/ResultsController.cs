using Domain.Interfaces;
using Domain.Models;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoCompareAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultsService resultsService;

        public ResultsController(IResultsService resultsService)
        {
            this.resultsService = resultsService;
        }

        [HttpGet(Name = "Results")]
        public async Task<ResultsResponseData> ExistingUser(string regNo, string email)
        {
            var results = resultsService.GetResultsInformation(regNo, email);

            return new ResultsResponseData()
            {
                Results = results.ResultsList,
                QuoteInformation = results.QuoteInformation
            };
        }

        [HttpPost(Name = "ResultsForNewUser")]
        public async Task<ResultsResponseData> NewUser(UserInformation userInformation)
        {
            var results = resultsService.GetResultsInformation(userInformation);

            return new ResultsResponseData()
            {
                Results = results.ResultsList,
                QuoteInformation = results.QuoteInformation
            };
        }
    }
}
