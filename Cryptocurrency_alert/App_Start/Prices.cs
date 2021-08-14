using System;
namespace Cryptocurrency_alert.App_Start
{
    public class Prices
    {
        public object _PLN, _USD, _EUR, _JPY, _GBP, _CHF;
        public object _BTC, _ETH, _Doge, _Lite, _NEO, _IOTA;
        public string mainCurrency;

        public Prices()
        {
            // example data

            mainCurrency = "PLN";
            _PLN = 10.2;
            _USD = 8;
            _EUR = 1.92;
            _JPY = 0.11;
            _GBP = 5.55;
            _CHF = 100.12;
            _BTC = 0.01;
            _ETH = 44212.01;
            _Doge = 343242;
            _Lite = 4.21;
            _NEO = 2.33;
            _IOTA = 0.09;
        }

        public void presentation()
        {
            Console.WriteLine(this._PLN + "\n" + this._USD + "\n"
                + this._EUR + "\n" + this._JPY + "\n" + this._GBP
                + "\n" + this._CHF + "\n" + this._BTC + "\n" + this._ETH
                + "\n" + this._Doge + "\n" + this._Lite + "\n" + this._NEO
                + "\n" + this._IOTA);
        }
    }
}
