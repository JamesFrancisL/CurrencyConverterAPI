using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TrainlinePriceCurrencyConverter.Core.LazyHttpClient;
using TrainlinePriceCurrencyConverter.Core.Services;

namespace TrainlinePriceCurrencyConverter.Core
{
    public class CoreStartup
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton(LazyHttpClientGenerator.SingletonHttpClient);
            services.AddTransient<ICurrencyProfileRequestUrlService, CurrencyProfileRequestUrlService>();
            services.AddTransient<ICurrencyProfileHttpRequestService, CurrencyProfileHttpRequestService>();
            services.AddTransient<ICurrencyProfileService, CurrencyProfileService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<ICurrencyConverter, CurrencyConverter>();
            services.AddTransient<IConvertedPriceService, ConvertedPriceService>();
            services.AddTransient<IPriceConversionRequestHandler, PriceConversionRequestHandler>();
        }
    }
}
