using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TrainlinePriceCurrencyConverter.Core.Services;
using NUnit.Framework;
using TrainlinePriceCurrencyConverter.Core.Model;
using TrainlinePriceCurrencyConverter.Functions.PriceEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace TrainlinePriceCurrencyConverter.Functions.Tests
{
    public class PriceConverterEndpointTests
    {
        private Mock<IPriceConversionRequestHandler> _priceConverterMock;
        private Mock<ILogger> _logServiceMock;
        private Mock<HttpRequest> _httpRequestMock;
        private Mock<IHeaderDictionary> _headerDictionary;

        [SetUp]
        public void Setup()
        {
            _priceConverterMock = new Mock<IPriceConversionRequestHandler>();
            _logServiceMock = new Mock<ILogger>();
            _httpRequestMock = new Mock<HttpRequest>();
            _headerDictionary = new Mock<IHeaderDictionary>();
        }

        [Test]
        public async void RequestSucceeds_HandlerReturnsData_ReturnsOkObjectResultStatusCode200()
        {
            //arrange
            _httpRequestMock.Setup(httpReq => httpReq.HttpContext.Response.Headers).Returns(_headerDictionary.Object);

            _priceConverterMock.Setup(priceConverter => priceConverter.PriceConversionRequest(It.IsAny<HttpRequest>()))
                .ReturnsAsync(new PriceResponse());

            var priceConverterEndpoint = new PriceConverterEndpoint(_priceConverterMock.Object);

            //act
            var endpointResponse = await priceConverterEndpoint.CoversionEndpoint(_httpRequestMock.Object, new Mock<ILogger>().Object) as OkObjectResult;

            //assert
            Assert.AreEqual(StatusCodes.Status200OK, endpointResponse.StatusCode); ;

        }
    }
}
