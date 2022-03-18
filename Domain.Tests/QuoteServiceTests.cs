using Domain.Interfaces;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Domain.Tests
{
    [TestClass]
    public class QuoteServiceTests
    {
        private readonly QuoteService _sut;

        public QuoteServiceTests()
        {
            var addressRepository = new Mock<IAddressRepository>();
            _sut = new QuoteService(addressRepository.Object);
        }


        [TestMethod]
        public void Given_An_Existing_User_When_They_Have_Previous_Quotes_Then_Most_Quote_Information_Remains_The_Same()
        {
        }
    }
}