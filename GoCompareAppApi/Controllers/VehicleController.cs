using Domain.Interfaces;
using Domain.Models;
using GoCompareAppApi.Models.Requests;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;
        private readonly IConfiguration configuration;


        public VehicleController(IVehicleService vehicleService, IConfiguration configuration)
        {
            this.vehicleService = vehicleService;
            this.configuration = configuration;
        }

        [HttpPost(Name = "GetVehicle")]
        public async Task<VehicleResponseData> Get(VehicleRequestData vehicleRequestData)
        {
            var computerVisionSection = configuration.GetSection("ComputerVision");
            var computerVisionSettings = new ComputerVisionSettings();
            computerVisionSection.Bind(computerVisionSettings);
            var regNo = await vehicleService.GetVehicle(vehicleRequestData.BaseSixtyFour, computerVisionSettings);
            return new VehicleResponseData(regNo);
        }
    }
}
