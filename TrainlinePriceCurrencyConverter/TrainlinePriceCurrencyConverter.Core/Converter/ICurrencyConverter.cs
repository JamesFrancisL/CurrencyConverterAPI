using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core
{
    public interface ICurrencyConverter
    {
        Task<decimal> ConvertedPrice(decimal testPrice, string targetCurrency, string targetPrice);
    }
}