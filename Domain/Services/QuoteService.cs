using Domain.Interfaces;
using Domain.Models;
using System.Linq;

namespace Domain.Services
{
    public class QuoteService : IQuoteService
    {
        public QuoteInformation AssumeQuote(List<QuoteInformation> previousQuotes)
        {
            var mostRecentQuote = previousQuotes.Last();
            return new QuoteInformation()
            {
                CoverDetails = new CoverDetails()
                {
                    CoverStartDate = DateTime.Now.AddDays(30),
                    CoverType = mostRecentQuote.CoverDetails.CoverType,
                    VoluntaryExcess = previousQuotes.Select(pq => pq.CoverDetails).Sum(cd => cd.VoluntaryExcess),
                    PaymentFrequency = mostRecentQuote.CoverDetails.PaymentFrequency,
                    FreeExcess = mostRecentQuote.CoverDetails.FreeExcess,
                    ContactPreference = mostRecentQuote.CoverDetails.ContactPreference,
                    SpecialTerms = mostRecentQuote.CoverDetails.SpecialTerms
                },
                DrivingDetails = new DrivingDetails()
                {
                    TypeOfLicence = mostRecentQuote.DrivingDetails.TypeOfLicence,
                    YearsSincePassedTest = (DateTime.Now.Year - mostRecentQuote.QuoteDate.Year) + mostRecentQuote.DrivingDetails.YearsSincePassedTest,
                    MonthsSincePassedTest = (DateTime.Now.Month - mostRecentQuote.QuoteDate.Month) + mostRecentQuote.DrivingDetails.MonthsSincePassedTest,
                    DVLAReportableMedicalConditions = mostRecentQuote.DrivingDetails.DVLAReportableMedicalConditions,
                    YearsNoClaimBonus = (DateTime.Now.Year + mostRecentQuote.QuoteDate.Year) + mostRecentQuote.DrivingDetails.YearsNoClaimBonus
                }
            };
        }
    }
}
