using Domain.Interfaces;
using GoCompareAppApi.Models.Requests;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text.RegularExpressions;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpPost(Name = "GetVehicle")]
        public async Task<VehicleResponseData> Get(VehicleRequestData vehicleRequestData)
        {
            var regNo = await vehicleService.GetVehicle(vehicleRequestData.BaseSixtyFour);
            return new VehicleResponseData(regNo);
        }
    }
}
