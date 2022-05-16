using Domain.Models;

namespace GoCompareAppApi.Models.Responses
{
    public class ResultsResponseData
    {
        public List<ResultInformation> Results { get; set; }
        public QuoteInformation QuoteInformation { get; set; }
    }
}