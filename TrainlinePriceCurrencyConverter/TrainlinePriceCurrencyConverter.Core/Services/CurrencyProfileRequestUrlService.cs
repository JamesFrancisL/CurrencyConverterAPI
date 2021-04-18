using System;
using System.Collections.Generic;
using System.Text;

namespace TrainlinePriceCurrencyConverter.Core.Services
{
    public class CurrencyProfileRequestUrlService : ICurrencyProfileRequestUrlService
    {
        public string CurrencyProfileRequestUrl(string currencyCode)
        {
            return $"https://trainlinerecruitment.github.io/exchangerates/api/latest/{currencyCode}.json";
        }
    }
}
