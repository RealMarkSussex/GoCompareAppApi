using Domain.Interfaces;
using Domain.Models;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceIncreaseController
    {
        private readonly IPriceIncreaseService priceIncreaseService;

        public PriceIncreaseController(IPriceIncreaseService priceIncreaseService)
        {
            this.priceIncreaseService = priceIncreaseService;
        }

        [HttpGet(Name = "GetPriceIncreases")]
        public Dictionary<string, double> GetPriceIncreases()
        {
            return priceIncreaseService.GetPricesIncreases();
        }
    }
}
