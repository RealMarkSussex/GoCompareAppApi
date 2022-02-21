using Domain.Interfaces;
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
        public async Task<ResultsResponseData> Get(string regNo, string email)
        {
            resultsService.GetResultsInformation(regNo, email);
            return new ResultsResponseData();
        }
    }
}
