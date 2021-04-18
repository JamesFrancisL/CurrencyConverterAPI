using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public class PriceConversionRequestHandler : IPriceConversionRequestHandler
    {
        private readonly IConvertedPriceService _convertedPriceService;

        public PriceConversionRequestHandler(IConvertedPriceService convertedPriceService)
        {
            _convertedPriceService = convertedPriceService;
        }
        public async Task<PriceResponse> PriceConversionRequest(HttpRequest httpRequest)
        {
            var price = decimal.Parse(httpRequest.Query["price"]);
            var sourceCurrency = httpRequest.Query["sourcecurrency"];
            var targetCurrency = httpRequest.Query["targetcurrency"];

            return await _convertedPriceService.ConvertedPriceResponse(price, sourceCurrency, targetCurrency);
        }
    }
}
