using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Money
    {
        protected internal int _amount;
        protected string _Currency;

        protected Money(int amount, string currency)
        {
            _amount = amount;
            _Currency = currency;
        }

        public string Currency
        {
            get => _Currency;
            set => _Currency = value;
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return _amount == money._amount &&
                              GetType().Equals(money.GetType());
        }

        public Money Times(int multiplier)
        {
            return null;
        }

        public static Money MakeDollars(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money MakeFrancs(int amount)
        {
            return new Franc(amount, "CHF");
        }
    }
}
