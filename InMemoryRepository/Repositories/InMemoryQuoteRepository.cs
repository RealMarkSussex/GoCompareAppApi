using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryQuoteRepository : IQuoteRepository
    {
        public List<QuoteInformation> GetPreviousQuoteInformation(string email)
        {
            return new List<QuoteInformation>()
            {
                new QuoteInformation()
                {
                    CoverDetails = new CoverDetails()
                    {
                        CoverStartDate = DateTime.Now,
                        CoverType = CoverType.Comprehensive,
                        VoluntaryExcess = 270,
                        SpecialTerms = false,
                        RenewalPrice = null,
                        PaymentFrequency = Domain.Enums.PaymentFrequency.Annually,
                        FreeExcess = true,
                        ContactPreference = false
                    },
                    VehicleDetails = new VehicleDetails()
                    {
                        CarUsage = CarUsage.SocialAndCommuting,
                        ParkedLocation = ParkedLocations.OnADriveway,
                        OvernightParkedLocation = ParkedLocations.OnADriveway,
                        Mileage = 4780,
                        PeakTimes = false,
                        PeakDriveRegularity = 0
                    },
                    ProposerDetails = new ProposerDetails()
                    {
                        Address = new Address()
                        {
                            AddressLineOne = "",
                            City = "",
                            County = "",
                            PostCode = "",
                            Town = ""
                        },

                        JobTitle = "Chicken Sexer",
                        JobSector = "Chickens",
                        TelephoneNumber = "118334"
                    },
                    DrivingDetails = new DrivingDetails()
                    {
                        TypeOfLicence = TypeOfLicence.UKFull,
                        YearsSincePassedTest = 2,
                        MonthsSincePassedTest = 2,
                        DVLAReportableMedicalConditions = false,
                        YearsNoClaimBonus = 0,
                        HasPassPlus = false,
                        ValidIAMCert = false,
                        OtherVehicles = false,
                        LicenceNumber = null,
                        PastClaims = false,
                        PastConvictions = false,
                        UnspentNonMotoringConvictions = false,
                    },
                    QuoteDate = DateTime.Now.AddDays(-3)
                }
            };
        }
    }
}
