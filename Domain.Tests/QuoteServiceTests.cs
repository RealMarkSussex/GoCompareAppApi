using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tests
{
    [TestClass]
    public class QuoteServiceTests
    {
        private readonly QuoteService _sut;
        private readonly List<QuoteInformation> _previousQuotes;
        private readonly UserInformation _userInformation;

        public QuoteServiceTests()
        {
            var addressRepository = new Mock<IAddressRepository>();
            _sut = new QuoteService(addressRepository.Object);
            _previousQuotes = new List<QuoteInformation>()
            {
                new QuoteInformation()
                {
                    CoverDetails = new CoverDetails()
                    {
                        CoverStartDate = DateTime.Now,
                        CoverType = CoverType.Comprehensive,
                        VoluntaryExcess = 250,
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
                    QuoteDate = DateTime.Now.AddDays(-3),
                }, // 250 Excess
                new QuoteInformation()
                {
                    CoverDetails = new CoverDetails()
                    {
                        CoverStartDate = DateTime.Now,
                        CoverType = CoverType.Comprehensive,
                        VoluntaryExcess = 100,
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
                    QuoteDate = DateTime.Now.AddDays(-3),
                }, // 100 Excess
                new QuoteInformation()
                {
                    CoverDetails = new CoverDetails()
                    {
                        CoverStartDate = DateTime.Now,
                        CoverType = CoverType.Comprehensive,
                        VoluntaryExcess = 500,
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
                    QuoteDate = DateTime.Now.AddDays(-3),
                }, // 500 Excess
            };
            _userInformation = new UserInformation()
            {
                DateOfBirth = DateTime.Now.ToString(),
                HouseNameNumber = "9",
                Postcode = "NP108UH",
                CoverType = CoverType.Comprehensive,
                RegNo = "DA67FWP"
            };
        }


        [TestMethod]
        public void Given_An_Existing_User_When_They_Have_Previous_Quotes_Then_Voluntary_Excess_Is_The_Average()
        {
            //Arrange
            var expected = 250;

            //Act
            var result = _sut.AssumeQuote(_previousQuotes);


            //Assert
            Assert.AreEqual(expected, result.CoverDetails.VoluntaryExcess);
        }

        [TestMethod]
        public void Given_An_Existing_User_When_They_Have_Previous_Quotes_Then_Most_Data_Is_Last_Quote_Data()
        {
            //Arrange
            var lastQuote = _previousQuotes.Last();

            //Act
            var result = _sut.AssumeQuote(_previousQuotes);


            //Assert
            Assert.AreEqual(result.CoverDetails.CoverType, lastQuote.CoverDetails.CoverType);
            Assert.AreEqual(result.CoverDetails.PaymentFrequency, lastQuote.CoverDetails.PaymentFrequency);
            Assert.AreEqual(result.CoverDetails.FreeExcess, lastQuote.CoverDetails.FreeExcess);
            Assert.AreEqual(result.CoverDetails.ContactPreference, lastQuote.CoverDetails.ContactPreference);
            Assert.AreEqual(result.CoverDetails.SpecialTerms, lastQuote.CoverDetails.SpecialTerms);
            Assert.AreEqual(result.DrivingDetails.TypeOfLicence, lastQuote.DrivingDetails.TypeOfLicence);
            Assert.AreEqual(result.DrivingDetails.HasPassPlus, lastQuote.DrivingDetails.HasPassPlus);

        }

        [TestMethod]
        public void Given_A_New_User_When_They_Have_Previous_Quotes_Then_User_Information_Preserved()
        {
            //Arrange

            //Act
            var result = _sut.AssumeQuote(_userInformation);


            //Assert
            Assert.AreEqual(result.CoverDetails.CoverType, _userInformation.CoverType);
        }

        [TestMethod]
        public void Given_A_New_User_When_They_Have_Previous_Quotes_Then_Excess_Is_250()
        {
            //Arrange
            var expected = 250;

            //Act
            var result = _sut.AssumeQuote(_userInformation);


            //Assert
            Assert.AreEqual(expected, result.CoverDetails.VoluntaryExcess);
        }
    }
}