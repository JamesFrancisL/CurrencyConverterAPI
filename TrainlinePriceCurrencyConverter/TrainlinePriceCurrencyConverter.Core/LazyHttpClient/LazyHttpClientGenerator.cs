using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TrainlinePriceCurrencyConverter.Core.LazyHttpClient
{
    public class LazyHttpClientGenerator
    {
        private static Lazy<HttpClient> _lazyHttpClient => new Lazy<HttpClient>(() =>
        {
            return new HttpClient();
        });
        public static HttpClient SingletonHttpClient => _lazyHttpClient.Value;
    }
}
