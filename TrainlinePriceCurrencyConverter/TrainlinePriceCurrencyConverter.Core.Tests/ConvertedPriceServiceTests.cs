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
    class ConvertedPriceServiceTests
    {
        Mock<ICurrencyConverter> _currencyConverterMock;

        [SetUp]
        public void Setup()
        { 
            _currencyConverterMock = new Mock<ICurrencyConverter>();
        }

        [Test]
        public async Task PriceAndCurrencySubmitted_CreatesPriceResponse_ReturnsPriceResponse()
        {
            //arrange
            var convertedPriceService = new ConvertedPriceService(_currencyConverterMock.Object);

            //act
            PriceResponse priceResponse = await convertedPriceService.ConvertedPriceResponse((decimal)1.12, "sourceCurrency", "targetCurrency");

            //assert
            Assert.IsInstanceOf<PriceResponse>(priceResponse);
        }

        [Test]
        public async Task PriceAndCurrencySubmitted_CreatesPriceResponseWithTargetCurrency_ReturnPriceResponse()
        {
            //arrange
            var price = (decimal)1.12;
            var sourceCurrency = "USD";
            var targetCurrency = "GBP";
            var convertedPriceService = new ConvertedPriceService(_currencyConverterMock.Object);

            //act
            PriceResponse priceResponse = await convertedPriceService.ConvertedPriceResponse(price, sourceCurrency, targetCurrency);

            //assert
            Assert.AreEqual(targetCurrency, priceResponse.Currency);
        }

        [Test]
        public async Task PriceAndCurrencySubmitted_CreatesPriceResponseWithConvertedPrice_ReturnPriceResponse()
        {
            //arrange
            var price = (decimal)1.12;
            var sourceCurrency = "USD";
            var targetCurrency = "GBP";
            var convertedPrice = (decimal)3.65;

            _currencyConverterMock.Setup(converter => converter.ConvertedPrice(price, sourceCurrency, targetCurrency))
                .ReturnsAsync(convertedPrice);

            var convertedPriceService = new ConvertedPriceService(_currencyConverterMock.Object);

            //act
            PriceResponse priceResponse = await convertedPriceService.ConvertedPriceResponse(price, sourceCurrency, targetCurrency);

            //assert
            Assert.AreEqual(convertedPrice, priceResponse.Price);
        }
    }
}
