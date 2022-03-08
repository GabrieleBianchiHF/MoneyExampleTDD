using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public abstract class Money
    {
        protected internal int _amount;
        protected string _Currency;

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

        public abstract Money Times(int multiplier);

        public static Money MakeDollars(int amount)
        {
            return new Dollar(amount);
        }

        public static Money MakeFrancs(int amount)
        {
            return new Franc(amount);
        }
    }
}
