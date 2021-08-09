using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaVantage.Net.Common.Currencies;
using AlphaVantage.Net.Common.Intervals;
using AlphaVantage.Net.Common.Size;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Forex;
using AlphaVantage.Net.Forex.Client;

namespace Cryptocurrency_alert.App_Start
{
    public class Financial_data
    {

        public string apiKeyo = "";

        public Financial_data()
        {
            this.apiKeyo = "7IKQ7YMBIF5SRWCN";
            CoreDemo();
        }

        public static async Task CoreDemo()
        {
            string apiKey = "7IKQ7YMBIF5SRWCN";
            using var client = new AlphaVantageClient(apiKey);
            using var forexClient = client.Forex();

            ForexTimeSeries forexTimeSeries = await forexClient.GetTimeSeriesAsync(
                PhysicalCurrency.GBP,
                PhysicalCurrency.PLN,
                Interval.Daily,
                OutputSize.Compact);

            ForexExchangeRate forexExchangeRate = await forexClient.GetExchangeRateAsync(PhysicalCurrency.USD, PhysicalCurrency.PLN);

            Console.WriteLine(Math.Round(forexExchangeRate.AskPrice, 2));
        }


    }


}
