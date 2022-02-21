using GoCompareAppApi.Models.Requests;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text.RegularExpressions;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController
    {
        static string subscriptionKey = "d6aab7f948944721b389d42bc20b80c3";
        static string endpoint = "https://gocovehicleapp.cognitiveservices.azure.com/";

        [HttpPost(Name = "GetVehicle")]
        public async Task<VehicleResponseData> Get(VehicleRequestData vehicleRequestData)
        {
            var imageBytes = Convert.FromBase64String(vehicleRequestData.BaseSixtyFour);
            
            var client = Authenticate();
            var ms = new MemoryStream(imageBytes);
            var resp = await client.RecognizePrintedTextInStreamAsync(true ,ms, OcrLanguages.Unk);
            var regNo = respToRegNo(resp);
            return new VehicleResponseData(regNo);
        }

        /*
            * AUTHENTICATE
            * Creates a Computer Vision client used by each example.
        */
        private static ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
              { Endpoint = endpoint };
            return client;
        }

        private static string respToRegNo(OcrResult ocrResult)
        {
            var regions = ocrResult.Regions.ToList();
            foreach(var region in regions)
            {
                var lines = region.Lines;
                foreach(var line in lines)
                {
                    var wordsText = line.Words.Select(w => w.Text);
                    var potentialRegNo = string.Join("", wordsText);
                    //var pattern = "(^[A-Z]{2}[0-9]{2}\\s?[A-Z]{3}$)|(^[A-Z][0-9]{1,3}[A-Z]{3}$)|(^[A-Z]{3}[0-9]{1,3}[A-Z]$)|(^[0-9]{1,4}[A-Z]{1,2}$)|(^[0-9]{1,3}[A-Z]{1,3}$)|(^[A-Z]{1,2}[0-9]{1,4}$)|(^[A-Z]{1,3}[0-9]{1,3}$)|(^[A-Z]{1,3}[0-9]{1,4}$)|(^[0-9]{3}[DX]{1}[0-9]{3}$)";

                    //var regexOptions = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
                    // regex = new Regex(pattern, regexOptions);
                    
                    //if (regex.IsMatch(potentialRegNo))
                    //{
                    //    return potentialRegNo;
                    //}

                    if(potentialRegNo.Length == 7)
                    {
                        return potentialRegNo;
                    }
                }
            }
            return "";
        }
    }
}
