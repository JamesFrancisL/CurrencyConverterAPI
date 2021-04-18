using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Services;

namespace TrainlinePriceCurrencyConverter.Core
{
    class CurrencyProfileHttpRequestServiceTests
    {
        string _httpResponse;
        Mock<HttpMessageHandler> _handlerMock;
        HttpClient _httpClient;
        Mock<ILogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _httpResponse = "test response";
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(_httpResponse),
               })
               .Verifiable();

            _httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri("https://notactually.used"),
            };

            _loggerMock = new Mock<ILogger>();
        }


        [Test]
        public async Task CurrencyCodeParamSubmitted_UrlRequested_ReturnsString()
        {
            //arrange
            var currencyProfileRequestUrlServiceMock = new Mock<ICurrencyProfileRequestUrlService>();

            CurrencyProfileHttpRequestService currencyProfileHttpRequestService =
                new CurrencyProfileHttpRequestService(_httpClient, currencyProfileRequestUrlServiceMock.Object, _loggerMock.Object);

            //act
            var urlResult = await currencyProfileHttpRequestService.CurrencyProfileResponse("USD");

            //assert
            Assert.IsInstanceOf<string>(urlResult);
        }

        [Test]
        public async Task CurrencyCodeParamSubmitted_UrlRequested_ReturnsResponseString()
        {
            //arrange
            var currencyProfileRequestUrlServiceMock = new Mock<ICurrencyProfileRequestUrlService>();
            CurrencyProfileHttpRequestService currencyProfileHttpRequestService =
                new CurrencyProfileHttpRequestService(_httpClient, currencyProfileRequestUrlServiceMock.Object, _loggerMock.Object);

            //act
            var currencyProfileResponse = await currencyProfileHttpRequestService.CurrencyProfileResponse("USD");

            //assert
            Assert.AreEqual(currencyProfileResponse, _httpResponse);
        }
    }
}
