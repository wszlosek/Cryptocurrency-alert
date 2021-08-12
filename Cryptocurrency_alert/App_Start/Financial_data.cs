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
            this.apiKeyo = "7IKQ7YMBIF5SRWCN";
            Fixer.SetApiKey("5d3bd7cccc69f9bf8029a730897072d7");
            Core("PLN");
        }

      /*  public static async Task Core()
        {
            string apiKey = "7IKQ7YMBIF5SRWCN";
            using var client = new AlphaVantageClient(apiKey);
            using var forexClient = client.Forex();

            ForexExchangeRate forexExchangeRate = await forexClient.GetExchangeRateAsync(PhysicalCurrency.USD, PhysicalCurrency.PLN);

            Console.WriteLine(Math.Round(forexExchangeRate.AskPrice, 2));
        } */

        public async void Core(string currency)
        {
            string apiKey = "7IKQ7YMBIF5SRWCN";
            using var client = new AlphaVantageClient(apiKey);
           
            var clientsC = new[] {client.Crypto(), client.Crypto(),
            client.Crypto()};

            Console.WriteLine("xd");

            /*
                        if (currency == "PLN")
                        {


                               prices._PLN = Fixer.Convert(Symbols.PLN, Symbols.PLN, 1);
                               prices._USD = Fixer.Convert(Symbols.PLN, Symbols.USD, 1);
                               prices._EUR = Fixer.Convert(Symbols.PLN, Symbols.EUR, 1);
                               prices._JPY = Fixer.Convert(Symbols.PLN, Symbols.JPY, 1);
                               prices._GBP = Fixer.Convert(Symbols.PLN, Symbols.GBP, 1);
                               prices._CHF = Fixer.Convert(Symbols.PLN, Symbols.CHF, 1); 

                            CryptoExchangeRate forexExchangeRate6 = await clientsC[0].GetExchangeRateAsync
                                (DigitalCurrency.BTC, PhysicalCurrency.PLN).ConfigureAwait(false);
                            prices._BTC = Math.Round(forexExchangeRate6.AskPrice, 2);

                            CryptoExchangeRate forexExchangeRate7 = await clientsC[0].GetExchangeRateAsync
                                (DigitalCurrency.ETH, PhysicalCurrency.PLN);
                            prices._ETH = Math.Round(forexExchangeRate7.AskPrice, 2);

                            CryptoExchangeRate forexExchangeRate8 = await clientsC[1].GetExchangeRateAsync
                                (DigitalCurrency.DOGE, PhysicalCurrency.PLN);
                            prices._Doge = Math.Round(forexExchangeRate8.AskPrice, 2);

                            CryptoExchangeRate forexExchangeRate9 = await clientsC[1].GetExchangeRateAsync
                                (DigitalCurrency.LTC, PhysicalCurrency.PLN);
                            prices._Lite = Math.Round(forexExchangeRate9.AskPrice, 2);

                            CryptoExchangeRate forexExchangeRate10 = await clientsC[2].GetExchangeRateAsync
                                (DigitalCurrency.NEO, PhysicalCurrency.PLN);
                            prices._NEO = Math.Round(forexExchangeRate10.AskPrice, 2);

                            CryptoExchangeRate forexExchangeRate11 = await clientsC[2].GetExchangeRateAsync
                                (DigitalCurrency.IOTA, PhysicalCurrency.PLN);
                            prices._IOTA = Math.Round(forexExchangeRate11.AskPrice, 2);

                            prices.presentation();

                        } */

            var symb = Symbols.PLN;
            var pcc = PhysicalCurrency.PLN;

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


            prices._PLN = Fixer.Convert(Symbols.PLN, symb, 1);
            prices._USD = Fixer.Convert(Symbols.USD, symb, 1);
            prices._EUR = Fixer.Convert(Symbols.EUR, symb, 1);
            prices._JPY = Fixer.Convert(Symbols.JPY, symb, 1);
            prices._GBP = Fixer.Convert(Symbols.GBP, symb, 1);
            prices._CHF = Fixer.Convert(Symbols.CHF, symb, 1);

            CryptoExchangeRate forexExchangeRate6 = await clientsC[0].GetExchangeRateAsync
                (DigitalCurrency.BTC, pcc).ConfigureAwait(false);
            prices._BTC = Math.Round(forexExchangeRate6.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate7 = await clientsC[0].GetExchangeRateAsync
                (DigitalCurrency.ETH, pcc);
            prices._ETH = Math.Round(forexExchangeRate7.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate8 = await clientsC[1].GetExchangeRateAsync
                (DigitalCurrency.DOGE, pcc);
            prices._Doge = Math.Round(forexExchangeRate8.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate9 = await clientsC[1].GetExchangeRateAsync
                (DigitalCurrency.LTC, pcc);
            prices._Lite = Math.Round(forexExchangeRate9.AskPrice, 2);

            CryptoExchangeRate forexExchangeRate10 = await clientsC[2].GetExchangeRateAsync
                (DigitalCurrency.NEO, pcc);
            prices._NEO = Math.Round(forexExchangeRate10.AskPrice, 2);


            prices.presentation();

        }


    }


}
