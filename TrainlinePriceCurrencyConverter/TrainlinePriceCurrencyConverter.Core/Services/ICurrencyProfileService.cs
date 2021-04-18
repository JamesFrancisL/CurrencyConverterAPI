using System.Threading.Tasks;
using TrainlinePriceCurrencyConverter.Core.Model;

namespace TrainlinePriceCurrencyConverter.Core
{
    public interface ICurrencyProfileService
    {
        Task<CurrencyProfile> CurrencyProfile(string targetCurrency);
    }
}