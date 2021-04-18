using System.Threading.Tasks;

namespace TrainlinePriceCurrencyConverter.Core
{
    public interface IRateService
    {
        Task<decimal> Rate(string sourceRate, string targetRate);
    }
}