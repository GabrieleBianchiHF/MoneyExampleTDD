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

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return _amount == money._amount &&
                              GetType().Equals(money.GetType());
        }

        public abstract Money Times(int multiplier);

        public static Dollar MakeDollars(int amount)
        {
            return new Dollar(amount);
        }
    }
}
