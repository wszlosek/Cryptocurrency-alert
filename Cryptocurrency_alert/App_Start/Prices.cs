using System;
namespace Cryptocurrency_alert.App_Start
{
    public class Prices
    {
        public object _PLN, _USD, _EUR, _JPY, _GBP, _CHF;
        public object _BTC, _ETH, _Doge, _Lite, _NEO, _IOTA;

        public Prices()
        {

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
