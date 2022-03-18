using Domain.Interfaces;
using Domain.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text.RegularExpressions;

namespace Domain.Services
{
    public class VehicleService : IVehicleService
    {
        static string subscriptionKey = "d6aab7f948944721b389d42bc20b80c3";
        static string endpoint = "https://gocovehicleapp.cognitiveservices.azure.com/";

        public async Task<string> GetVehicle(string base64)
        {
            var imageBytes = Convert.FromBase64String(base64);

            var client = Authenticate();
            var ms = new MemoryStream(imageBytes);
            var resp = await client.RecognizePrintedTextInStreamAsync(true, ms, OcrLanguages.Unk);
            return respToRegNo(resp);
        }

        private static string respToRegNo(OcrResult ocrResult)
        {
            var regions = ocrResult.Regions.ToList();
            foreach (var region in regions)
            {
                var lines = region.Lines;
                foreach (var line in lines)
                {
                    var wordsText = line.Words.Select(w => w.Text);
                    var potentialRegNo = string.Join(" ", wordsText);
                    var pattern = "(^[A-Z]{2}[0-9]{2} [A-Z]{3}$)|(^[A-Z][0-9]{1,3} [A-Z]{3}$)|(^[A-Z]{3} [0-9]{1,3}[A-Z]$)|(^[0-9]{1,4} [A-Z]{1,2}$)|(^[0-9]{1,3} [A-Z]{1,3}$)|(^[A-Z]{1,2} [0-9]{1,4}$)|(^[A-Z]{1,3} [0-9]{1,3}$)";

                    var regex = new Regex(pattern);

                    if (regex.IsMatch(potentialRegNo))
                    {
                        return potentialRegNo;
                    }
                }
            }
            return "";
        }

        private static ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
              { Endpoint = endpoint };
            return client;
        }
    }
}
