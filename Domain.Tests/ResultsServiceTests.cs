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
    public class ResultsServiceTests
    {
        private readonly ResultsService _sut;
        private readonly List<QuoteInformation> _previousQuotes;
        private readonly UserInformation _userInformation;

        public ResultsServiceTests()
        {
            var quoteRepository = new Mock<IQuoteRepository>();
            var vehicleRepository = new Mock<IVehicleRepository>();
            var resultsRepository = new Mock<IResultsRepository>();
            var quotesService = new Mock<IQuoteService>();

            _sut = new ResultsService(quoteRepository.Object, vehicleRepository.Object, quotesService.Object, resultsRepository.Object);
        }
    }
}