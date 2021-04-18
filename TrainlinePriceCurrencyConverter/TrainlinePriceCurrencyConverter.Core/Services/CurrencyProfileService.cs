using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public class CurrencyProfileService : ICurrencyProfileService
    {
        private readonly ICurrencyProfileHttpRequestService _currencyProfileHttpRequestService;

        public CurrencyProfileService(ICurrencyProfileHttpRequestService currencyProfileHttpRequestService)
        {
            _currencyProfileHttpRequestService = currencyProfileHttpRequestService;
        }
        public async Task<CurrencyProfile> CurrencyProfile(string targetCurrency)
        {
            var sourceCurrencyProfile = JsonConvert.DeserializeObject<CurrencyProfile>(
                await _currencyProfileHttpRequestService.CurrencyProfileResponse(targetCurrency));

            return sourceCurrencyProfile;
        }
    }
}
