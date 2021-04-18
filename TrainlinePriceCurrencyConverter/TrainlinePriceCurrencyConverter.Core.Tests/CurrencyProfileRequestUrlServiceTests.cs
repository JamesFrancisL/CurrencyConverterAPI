using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TrainlinePriceCurrencyConverter.Core.Services;

namespace TrainlinePriceCurrencyConverter.Core
{
    public class CurrencyProfileRequestUrlServiceTests
    {
        [Test]
        public void CurrencyCodeParamSubmitted_UrlRequested_ReturnsString()
        {
            //arrange
            CurrencyProfileRequestUrlService currencyProfileRequestUrlService = new CurrencyProfileRequestUrlService();

            //act
            var urlResult = currencyProfileRequestUrlService.CurrencyProfileRequestUrl("USD");

            //assert
            Assert.IsInstanceOf<string>(urlResult);
        }

        [Test]
        public void CurrencyCodeParamSubmitted_UrlRequested_ReturnsStringContainingCurrencyCode()
        {
            //arrange
            CurrencyProfileRequestUrlService currencyProfileRequestUrlService = new CurrencyProfileRequestUrlService();
            var currencyCode = "USD";

            //act
            var urlResult = currencyProfileRequestUrlService.CurrencyProfileRequestUrl(currencyCode);

            //assert
            StringAssert.Contains(currencyCode, urlResult);
        }
    }
}
