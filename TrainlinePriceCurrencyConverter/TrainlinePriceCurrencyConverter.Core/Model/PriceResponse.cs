using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainlinePriceCurrencyConverter.Core.Model
{
    public class PriceResponse
    {
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    }
}
