using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;
using TrainlinePriceCurrencyConverter.Core.Services;

namespace TrainlinePriceCurrencyConverter.Core
{
    class CurrencyProfileServiceTests
    {
        [Test]
        public async Task CurrenciesCodeParam_SubmittedHttpClient_ReturnsCurrencyProfile()
        {
            //arrange
            var currencyCode = "USD";
            var testJson = "{ \"base\": \"GBP\" }";
            var currencyProfileHttpRequestServiceMock = new Mock<ICurrencyProfileHttpRequestService>();

            currencyProfileHttpRequestServiceMock.Setup(currencyRequest =>
                        currencyRequest.CurrencyProfileResponse(currencyCode)).ReturnsAsync(testJson);

            CurrencyProfileService currencyProfileService = new CurrencyProfileService(
                currencyProfileHttpRequestServiceMock.Object);

            //act
            var currencyProfile = await currencyProfileService.CurrencyProfile("USD");

            //assert
            Assert.IsInstanceOf<CurrencyProfile>(currencyProfile);
        }

    }
}
