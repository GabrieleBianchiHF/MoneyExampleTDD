using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            _amount = amount;
            _Currency = "USD";
        }

        public override Money Times(int multiplier)
        {
            return new Dollar(_amount * multiplier);
        }
    }
}
