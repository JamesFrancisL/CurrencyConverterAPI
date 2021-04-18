using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core.Tests
{
    class RateServiceTests
    {
        private Mock<ICurrencyProfileService> _currencyProfileMock;

        [SetUp]
        public void Setup()
        {
            _currencyProfileMock = new Mock<ICurrencyProfileService>();
        }
        [Test]
        public async Task TwoCurrenciesCodeParam_SubmittedToRateApi_ReturnsReply()
        {
            //arrange
            var currencyProfile = new CurrencyProfile { Rates = 
                new Dictionary<string, decimal> { { "GBP", (decimal)1 } } };
            _currencyProfileMock.Setup(currencyProfileService => currencyProfileService.CurrencyProfile("USD"))
                .ReturnsAsync(currencyProfile);
            var rateService = new RateService(_currencyProfileMock.Object);

            //act
            var rateReturn = await rateService.Rate("USD", "GBP");

            //assert
            Assert.IsInstanceOf<decimal>(rateReturn);

        }

        [Test]
        public async Task TwoCurrencyCodeParam_Returns_ReturnsReply()
        {
            //arrange
            var currencyProfile = new CurrencyProfile { Rates =
                new Dictionary<string, decimal> { { "GBP", (decimal)1 } }
            };
            _currencyProfileMock.Setup(currencyProfileService => currencyProfileService.CurrencyProfile("GBP"))
                .ReturnsAsync(currencyProfile);
            var rateService = new RateService(_currencyProfileMock.Object);

            //act
            var rateReturn = await rateService.Rate("GBP", "GBP");

            //assert
            Assert.IsInstanceOf<decimal>(rateReturn);

        }
    }
}
