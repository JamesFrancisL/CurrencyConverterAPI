using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public interface ICurrencyProfileHttpRequestService
    {
        Task<string> CurrencyProfileResponse(string currencyCode);
    }
}