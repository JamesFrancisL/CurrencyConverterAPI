using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public class ConvertedPriceService : IConvertedPriceService
    {
        private readonly ICurrencyConverter _currencyConverter;

        public ConvertedPriceService(ICurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
        }

        public async Task<PriceResponse> ConvertedPriceResponse(decimal price, string sourceCurency, string targetCurrency)
        {
            var newPrice = await _currencyConverter.ConvertedPrice(price, sourceCurency, targetCurrency);
            return new PriceResponse
            {
                Price = newPrice
                ,
                Currency = targetCurrency
            };
        }
    }
}
