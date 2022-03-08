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
        }

        public override string Currency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Money Times(int multiplier)
        {
            return new Dollar(_amount * multiplier);
        }
    }
}
