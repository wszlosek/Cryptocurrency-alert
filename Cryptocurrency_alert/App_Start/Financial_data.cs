using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AlphaVantage.Net.Common.Currencies;
using AlphaVantage.Net.Common.Intervals;
using AlphaVantage.Net.Common.Size;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Forex;
using AlphaVantage.Net.Forex.Client;
using AlphaVantage.Net.Crypto;
using AlphaVantage.Net.Crypto.Client;
using FixerSharp;

namespace Cryptocurrency_alert.App_Start
{
    public class Financial_data
    {

        public string apiKeyo = "";
        Prices prices = new Prices();

        public Financial_data()
        {
            this.apiKeyo = "HT4SP8Y2XBI0EQMA";
            Fixer.SetApiKey("5d3bd7cccc69f9bf8029a730897072d7");
        }

        public async void Core(string currency, List<string> IsChecked)
        {
            string apiKey = "HT4SP8Y2XBI0EQMA";
            using var client = new AlphaVantageClient(apiKey);

            var clientsC = new[] {client.Crypto(), client.Crypto(),
              client.Crypto()};

            var symb = Symbols.PLN;
            var pcc = PhysicalCurrency.PLN;

            prices.mainCurrency = currency;

            if (currency == "USD")
            {
                symb = Symbols.USD;
                pcc = PhysicalCurrency.USD;
            }

            else if (currency == "EUR")
            {
                symb = Symbols.EUR;
                pcc = PhysicalCurrency.EUR;
            }

            else if (currency == "JPY")
            {
                symb = Symbols.JPY;
                pcc = PhysicalCurrency.JPY;
            }

            else if (currency == "GBP")
            {
                symb = Symbols.GBP;
                pcc = PhysicalCurrency.GBP;
            }

            else if (currency == "CHF")
            {
                symb = Symbols.CHF;
                pcc = PhysicalCurrency.CHF;
            }


            this.prices._PLN = Math.Round(Fixer.Convert(Symbols.PLN, symb, 1), 2);
            this.prices._USD = Math.Round(Fixer.Convert(Symbols.USD, symb, 1), 2);
            this.prices._EUR = Math.Round(Fixer.Convert(Symbols.EUR, symb, 1), 2);
            this.prices._JPY = Math.Round(Fixer.Convert(Symbols.JPY, symb, 1), 2);
            this.prices._GBP = Math.Round(Fixer.Convert(Symbols.GBP, symb, 1), 2);
            this.prices._CHF = Math.Round(Fixer.Convert(Symbols.CHF, symb, 1), 2);

            CryptoExchangeRate forexExchangeRate6 = await clientsC[0].GetExchangeRateAsync
                (DigitalCurrency.BTC, pcc).ConfigureAwait(false);
            this.prices._BTC = Math.Round(forexExchangeRate6.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate7 = await clientsC[0].GetExchangeRateAsync
                (DigitalCurrency.ETH, pcc);
            this.prices._ETH = Math.Round(forexExchangeRate7.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate8 = await clientsC[1].GetExchangeRateAsync
                (DigitalCurrency.DOGE, pcc);
            this.prices._Doge = Math.Round(forexExchangeRate8.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate9 = await clientsC[1].GetExchangeRateAsync
                (DigitalCurrency.LTC, pcc);
            this.prices._Lite = Math.Round(forexExchangeRate9.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate10 = await clientsC[2].GetExchangeRateAsync
                (DigitalCurrency.NEO, pcc);
            this.prices._NEO = Math.Round(forexExchangeRate10.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate11 = await clientsC[2].GetExchangeRateAsync
                (DigitalCurrency.IOTA, pcc);
            this.prices._IOTA = Math.Round(forexExchangeRate11.AskPrice, 2);


            var doc = new pdfDocument();
            doc.generateDocument(prices, IsChecked);
        }


    }


}
