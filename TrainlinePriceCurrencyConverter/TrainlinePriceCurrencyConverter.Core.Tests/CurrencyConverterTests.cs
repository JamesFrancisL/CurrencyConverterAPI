using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core.Tests
{
    class CurrencyConverterTests
    {
        private Mock<IRateService> _rateRetrieverMock;

        [SetUp]
        public void Setup()
        {
            _rateRetrieverMock = new Mock<IRateService>();
        }

        [Test]
        public async Task WhenRateIsOne_PriceIsUnchanged_ReturnsSubmittedPriceValue()
        {
            //arrange
            var testPrice = 1;

            _rateRetrieverMock.Setup(rateRetriever => rateRetriever.Rate("GBP", "GBP")).ReturnsAsync((decimal) 1);

            var currencyConverter = new CurrencyConverter(_rateRetrieverMock.Object);

            //act
            var convertedPrice = await currencyConverter.ConvertedPrice(testPrice, "GBP", "GBP");

            //assert
            Assert.AreEqual(testPrice, convertedPrice);
        }

        [Test]
        public async Task WhenRateIsTwoAndPriceIsOne_PriceIsMultipliedByRateTwo_ReturnsNewPriceTwo()
        {
            //arrange
            var testPrice = 1;

            _rateRetrieverMock.Setup(rateRetriever => rateRetriever.Rate("GBP", "USD")).ReturnsAsync(2);

            var currencyConverter = new CurrencyConverter(_rateRetrieverMock.Object);

            //act
            var convertedPrice = await currencyConverter.ConvertedPrice(testPrice, "GBP", "USD");

            //assert
            Assert.AreEqual(2, convertedPrice);
        }

        [Test]
        public async Task WhenRateIsTwopPointFourAndPriceIsOnePointFiveOne_PriceIsMultipliedByRateTwo_ReturnsNewPriceTwo()
        {
            //arrange
            var testPrice = (decimal)1.51;

            _rateRetrieverMock.Setup(rateRetriever => rateRetriever.Rate("GBP", "USD")).ReturnsAsync((decimal)2.4);

            var currencyConverter = new CurrencyConverter(_rateRetrieverMock.Object);

            //act
            var convertedPrice = await currencyConverter.ConvertedPrice(testPrice, "GBP", "USD");

            //assert
            Assert.AreEqual(3.624, convertedPrice);
        }
    }
}
