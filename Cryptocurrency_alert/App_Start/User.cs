using System;
namespace Cryptocurrency_alert.App_Start
{
    public class User
    {
        public string currency;
        public Prices prices = new Prices();

        public User(string currency)
        {
            this.currency = currency;
        }

        public string introduction()
        {
            return @"Your currency is " + this.currency;
        }

        public string calculate()
        {
            switch (this.currency)
            {
                
            }
            return "";
        }
    }
}
