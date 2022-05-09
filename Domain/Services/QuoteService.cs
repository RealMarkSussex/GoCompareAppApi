using Domain.Interfaces;
using Domain.Models;
using System.Linq;

namespace Domain.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IAddressRepository addressRepository;
        private const int AverageAgeToPassTest = 17;
        private const int AverageAnnualMileage = 7000;

        public QuoteService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public QuoteInformation AssumeQuote(List<QuoteInformation> previousQuotes)
        {
            var mostRecentQuote = previousQuotes.Last();
            return new QuoteInformation()
            {
                CoverDetails = new CoverDetails()
                {
                    CoverStartDate = DateTime.Now.AddDays(30),
                    CoverType = mostRecentQuote.CoverDetails.CoverType,
                    VoluntaryExcess = ((int)previousQuotes.Select(pq => pq.CoverDetails).Average(cd => cd.VoluntaryExcess)),
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
                    YearsNoClaimBonus = (DateTime.Now.Year + mostRecentQuote.QuoteDate.Year) + mostRecentQuote.DrivingDetails.YearsNoClaimBonus,
                    HasPassPlus = mostRecentQuote.DrivingDetails.HasPassPlus,
                    ValidIAMCert = mostRecentQuote.DrivingDetails.ValidIAMCert,
                    OtherVehicles = mostRecentQuote.DrivingDetails.OtherVehicles,
                    LicenceNumber = mostRecentQuote.DrivingDetails.LicenceNumber,
                    PastClaims = mostRecentQuote.DrivingDetails.PastClaims,
                    PastConvictions = mostRecentQuote.DrivingDetails.PastConvictions,
                    UnspentNonMotoringConvictions = mostRecentQuote.DrivingDetails.UnspentNonMotoringConvictions
                },
                ProposerDetails = mostRecentQuote.ProposerDetails,
                VehicleDetails = new VehicleDetails()
                {
                    CarUsage = mostRecentQuote.VehicleDetails.CarUsage,
                    ParkedLocation = mostRecentQuote.VehicleDetails.ParkedLocation,
                    OvernightParkedLocation = mostRecentQuote.VehicleDetails.OvernightParkedLocation,
                    Mileage = ((int)previousQuotes.Select(pq => pq.VehicleDetails).Average(pq => pq.Mileage)),
                    PeakDriveRegularity = mostRecentQuote.VehicleDetails.PeakDriveRegularity,
                }
            };
        }

        public QuoteInformation AssumeQuote(UserInformation userInformation)
        {
            var address = addressRepository.GetAddress(userInformation.Postcode, userInformation.HouseNameNumber);
            return new QuoteInformation()
            {
                CoverDetails = new CoverDetails()
                {
                    CoverStartDate = DateTime.Now.AddDays(30),
                    CoverType = userInformation.CoverType,
                    VoluntaryExcess = 250,
                    PaymentFrequency = Enums.PaymentFrequency.Annually,
                    FreeExcess = true,
                    ContactPreference = false,
                    SpecialTerms = false
                },
                DrivingDetails = new DrivingDetails()
                {
                    TypeOfLicence = Enums.TypeOfLicence.UKFull,
                    YearsSincePassedTest = DateTime.Now.Year - DateTime.Parse(userInformation.DateOfBirth).Year - AverageAgeToPassTest,
                    MonthsSincePassedTest = 0,
                    DVLAReportableMedicalConditions = false,
                    YearsNoClaimBonus = DateTime.Now.Year - DateTime.Parse(userInformation.DateOfBirth).Year - AverageAgeToPassTest,
                    HasPassPlus = false,
                    ValidIAMCert = false,
                    OtherVehicles = false,
                    LicenceNumber = null,
                    PastClaims = false,
                    PastConvictions = false,
                    UnspentNonMotoringConvictions = false
                },
                ProposerDetails = new ProposerDetails()
                {
                    Address = address,
                },
                VehicleDetails = new VehicleDetails()
                {
                    CarUsage = Enums.CarUsage.SocialAndCommuting,
                    ParkedLocation = Enums.ParkedLocations.OnTheRoadAtHome,
                    OvernightParkedLocation = Enums.ParkedLocations.OnTheRoadAtHome,
                    Mileage = AverageAnnualMileage,
                    PeakDriveRegularity = 3
                }
            };
        }
    }
}
