using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Money
    {
        protected int _amount;

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return _amount == money._amount;
        }
    }
}
