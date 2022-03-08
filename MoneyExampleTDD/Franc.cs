using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Franc : Money
    {
        public Franc(int amount, string currency)
        {
            _amount = amount;
            _Currency = currency;
        }

        public override Money Times(int multiplier)
        {
            return MakeFrancs(_amount * multiplier);
        }
    }
}
