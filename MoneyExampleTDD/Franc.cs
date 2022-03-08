using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Franc : Money
    {
        public Franc(int amount)
        {
            _amount = amount;
            _Currency = "CHF";
        }

        public override Money Times(int multiplier)
        {
            return new Franc(_amount * multiplier);
        }
    }
}
