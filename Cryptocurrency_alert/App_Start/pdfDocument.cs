using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IronPdf;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Cryptocurrency_alert.App_Start
{
    public class pdfDocument
    {
        public void generateDocument(Prices p, List<String> currencies)
        {
            List<String> allCurrencies = new List<string> { "PLN", "USD", "EUR", "JPY", "GBP",
                "CHF", "Bitcoin", "Ethereum", "Dogecoin", "Litecoin", "NEO", "IOTA" };
            List<Object> allValues = new List<object> { p._PLN, p._USD, p._EUR, p._JPY, p._GBP,
                p._CHF, p._BTC, p._ETH, p._Doge, p._Lite, p._NEO, p._IOTA };
            List<int> allSign = new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };

            Object[] values = new Object[(currencies.Count)];
            int[] sign = new int[(currencies.Count)];

            for (int i = 0; i < currencies.Count; i++)
            {
                int n = allCurrencies.IndexOf(currencies[i]);
                values[i] = allValues[n];
                sign[i] = allSign[n];

                Console.WriteLine(currencies[i]);
                Console.WriteLine(values[i]);
                Console.WriteLine(sign[i]);
            }

            // clearLists(ref currencies, ref values, ref sign, p.mainCurrency);
            clearArrays(ref currencies, ref values, ref sign, p.mainCurrency);

            var htmlToPdf = new HtmlToPdf();

            string now = (DateTime.Now).ToString();
            string html = $"<h1><center>Cryptocurrency alert app results</center></h1><br></br><br></br>" +
                $"<center><p>You chose as their currency {p.mainCurrency}. You can see the prices of other currencies " +
                $"and cryptocurrencies below.</p></center> <br></br> <br></br>";
            string toHtml = "";

            int j = 0;

            while (sign[j] != 1) // for currency
            {
                if (j % 2 == 0)
                {
                    toHtml += "<p> " + generateSpaces(8) + " 1 " + currencies[j] + " = " + values[j]
                        + " " + p.mainCurrency + generateSpaces(50 - values[j].ToString().Length);
                }

                else
                {
                    toHtml += " 1 " + currencies[j] + " = " + values[j]
                        + " " + p.mainCurrency + "</p>";
                }

                j += 1;

                if (j >= sign.Length)
                {
                    if (j % 2 == 1)
                    {
                        toHtml += "</p> ";
                    }

                    break;
                }
            }

            toHtml += "<br></br> <br></br>";
            int k = j; // k = j - 1, when j%2 == 1

            if (j % 2 == 1)
            {
                toHtml += " <p> ";
                k = j - 1;
            }
            
            while (true) // for crypto
            {
                if (j >= sign.Length)
                {
                    break;
                }

                if (k % 2 == 0)
                {
                    toHtml += "<p> " + generateSpaces(8) + " 1 " + currencies[j] + " = " + values[j]
                        + " " + p.mainCurrency + generateSpaces(50 - values[j].ToString().Length - currencies[j].Length);
                }

                else
                {
                    toHtml += " 1 " + currencies[j] + " = " + values[j]
                        + " " + p.mainCurrency + "</p>";
                }

                j += 1;
                k += 1;
            }
            

            html += toHtml + $"</center><br></br><br></br> <center><strong>(As of {now})</strong></center>";
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);
   
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "cryptocurrency.pdf"));
        }

        private void clearLists(ref List<String> first, ref List<Object> second,
            ref List<int> third, string pattern)
        {
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] == pattern)
                {
                    first.RemoveAt(i);
                    second.RemoveAt(i);
                    third.RemoveAt(i);
                }
            }

        }

        private void clearArrays(ref List<string> first, ref Object[] second,
            ref int[] third, string pattern)
        {
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] == pattern)
                {
                    first.RemoveAt(i);
                    var s1 = second.ToList();
                    var s2 = third.ToList();

                    s1.RemoveAt(i);
                    s2.RemoveAt(i);

                    second = s1.ToArray();
                    third = s2.ToArray();
                }
            }

        }

        private string generateSpaces(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += "&nbsp ";
            }

            return s;
        }
    }
}
