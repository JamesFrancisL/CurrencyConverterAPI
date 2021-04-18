using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public interface IConvertedPriceService
    {
        Task<PriceResponse> ConvertedPriceResponse(decimal price, string sourceCurency, string targetCurrency);
    }
}