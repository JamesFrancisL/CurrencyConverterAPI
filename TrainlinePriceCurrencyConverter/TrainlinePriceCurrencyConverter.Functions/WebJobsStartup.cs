using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using TrainlinePriceCurrencyConverter.Core;
using TrainlinePriceCurrencyConverter.Functions;

[assembly: WebJobsStartup(typeof(WebJobsStartup))]
namespace TrainlinePriceCurrencyConverter.Functions
{
    class WebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            CoreStartup.Configure(builder.Services);
        }
    }
}
