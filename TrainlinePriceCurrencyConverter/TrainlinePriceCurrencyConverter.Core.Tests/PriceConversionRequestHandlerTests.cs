using Microsoft.AspNetCore.Http;
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
    class PriceConversionRequestHandlerTests
    {
        private Mock<IConvertedPriceService> _convertedPriceServiceMock;

        [SetUp]
        public void Setup()
        {
            _convertedPriceServiceMock = new Mock<IConvertedPriceService>();
        }
        
        [Test]
        public async Task ReceivedRequest_RetrievesQueryParam_ReturnServiceResponse()
        {
            //arrange
            var price = "1";
            var sourceCurrency = "USD";
            var targetCurrency = "GBP";
            _convertedPriceServiceMock.Setup(priceConverter =>
            priceConverter.ConvertedPriceResponse((decimal)1, sourceCurrency, targetCurrency))
                .ReturnsAsync(new PriceResponse { Currency = targetCurrency });
            PriceConversionRequestHandler priceConversionRequestHandler = new PriceConversionRequestHandler(_convertedPriceServiceMock.Object);

            var _httpRequestMock = new Mock<HttpRequest>();
            _httpRequestMock.Setup(httpReq => httpReq.Query["price"]).Returns("1");
            _httpRequestMock.Setup(httpReq => httpReq.Query["sourcecurrency"]).Returns("USD");
            _httpRequestMock.Setup(httpReq => httpReq.Query["targetcurrency"]).Returns("GBP");

            //act
            var priceResponse = await priceConversionRequestHandler.PriceConversionRequest(_httpRequestMock.Object);

            //assert
            Assert.IsInstanceOf<PriceResponse>(priceResponse);

        }

        [Test]
        public async Task ReceivedRequest_RetrievesQuearyResponseFromConversionService_ReturnServiceResponse()
        {
            //arrange
            var price = "1";
            var sourceCurrency = "USD";
            var targetCurrency = "GBP";
            _convertedPriceServiceMock.Setup(priceConverter =>
            priceConverter.ConvertedPriceResponse((decimal)1, sourceCurrency, targetCurrency))
                .ReturnsAsync(new PriceResponse { Currency = targetCurrency});
            PriceConversionRequestHandler priceConversionRequestHandler = new PriceConversionRequestHandler(_convertedPriceServiceMock.Object);

            var _httpRequestMock = new Mock<HttpRequest>();
            _httpRequestMock.Setup(httpReq => httpReq.Query["price"]).Returns(price);
            _httpRequestMock.Setup(httpReq => httpReq.Query["sourcecurrency"]).Returns(sourceCurrency);
            _httpRequestMock.Setup(httpReq => httpReq.Query["targetcurrency"]).Returns(targetCurrency);

            //act
            var priceResponse = await priceConversionRequestHandler.PriceConversionRequest(_httpRequestMock.Object);

            //assert
            Assert.AreEqual(targetCurrency, priceResponse.Currency);
        }
    }
}
