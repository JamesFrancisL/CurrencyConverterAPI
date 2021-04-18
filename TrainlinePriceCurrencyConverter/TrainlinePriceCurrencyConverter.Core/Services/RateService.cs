using System;
using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core
{
    public class RateService : IRateService
    {
        private readonly ICurrencyProfileService _currencyProfileService;

        public RateService(ICurrencyProfileService currencyProfileService)
        {
            _currencyProfileService = currencyProfileService;
        }

        public async Task<decimal> Rate(string sourceCurrency, string targetCurrency)
        {
            var sourceCurrencyProfile = await _currencyProfileService.CurrencyProfile(sourceCurrency);
            
            var rateRetrieved = sourceCurrencyProfile.Rates.TryGetValue(targetCurrency, out decimal rate);

            if (!rateRetrieved) throw new ArgumentException("Currency Codes Not Found");
            return rate;
        }
    }
}