using System;
using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private IRateService _rateRetriever;

        public CurrencyConverter(IRateService rateRetriever)
        {
            _rateRetriever = rateRetriever;
        }

        public async Task<decimal> ConvertedPrice(decimal price, string sourceCurrency, string targetCurrency)
        {
            return price * await _rateRetriever.Rate(sourceCurrency, targetCurrency);
        }
    }
}