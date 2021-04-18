//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public class CurrencyProfileHttpRequestService : ICurrencyProfileHttpRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly ICurrencyProfileRequestUrlService _currencyProfileRequestUrlService;
        private readonly ILogger _logger;

        public CurrencyProfileHttpRequestService(HttpClient httpClient
            , ICurrencyProfileRequestUrlService currencyProfileRequestUrlService
            , ILogger logger)
        {
            _httpClient = httpClient;
            _currencyProfileRequestUrlService = currencyProfileRequestUrlService;
            _logger = logger;
        }
        public async Task<string> CurrencyProfileResponse(string currencyCode)
        {
            var requestUrl = _currencyProfileRequestUrlService.CurrencyProfileRequestUrl(currencyCode);
            try
            {
                return await (await _httpClient
                    .GetAsync(requestUrl)).Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"Error when attempting to retrieve request from {requestUrl}");
                throw;
            }
            
        }
    }
}
