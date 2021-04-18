using System;
using System.Collections.Generic;
using System.Text;

namespace TrainlinePriceCurrencyConverter.Core.Model
{
    public class CurrencyProfile
    {
        public string Base { get; set; }
        public string Date { get; set; }
        public int TimeLastUpdated { get; set; }
        //public Rates Rates { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
