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
        }

        public Franc Times(int multiplier)
        {
            return new Franc(_amount * multiplier);
        }
    }
}
