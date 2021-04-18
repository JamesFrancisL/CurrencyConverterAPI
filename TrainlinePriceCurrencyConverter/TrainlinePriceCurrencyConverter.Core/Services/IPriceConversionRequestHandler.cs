using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public interface IPriceConversionRequestHandler
    {
        Task<PriceResponse> PriceConversionRequest(HttpRequest httpRequest);
    }
}