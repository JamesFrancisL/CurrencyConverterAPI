using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TrainlinePriceCurrencyConverter.Core;
using TrainlinePriceCurrencyConverter.Core.Services;

namespace TrainlinePriceCurrencyConverter.Functions.PriceEndpoints
{
    public class PriceConverterEndpoint
    {
        private readonly IPriceConversionRequestHandler _priceConverterRequestHandler;

        public PriceConverterEndpoint(IPriceConversionRequestHandler priceConverterRequestHandler)
        {
            _priceConverterRequestHandler = priceConverterRequestHandler;
        }
        [FunctionName(nameof(PriceConverterEndpoint))]
        public async Task<IActionResult> CoversionEndpoint(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "priceconverterendpoint")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("PriceConverterEndpoint received a request.");

            try {
                var convertedPrice = await _priceConverterRequestHandler.PriceConversionRequest(req);


                return new OkObjectResult(convertedPrice);
            }
            catch (Exception e)
            { 
                log.LogError(e, "Couldn't process request");
                return new OkObjectResult("Sorry we couldn't convert that currency at this time" +
                    ", please select from USD, GBP or EUR and try again");
            }
            
        }
    }
}

