using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Dollar
    {
        public int amount;

        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            return amount == (obj as Dollar).amount;
        }
    }
}
