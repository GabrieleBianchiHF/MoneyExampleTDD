using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Dollar
    {
        private int _amount;

        public Dollar(int amount)
        {
            this._amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(_amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            return _amount == (obj as Dollar)._amount;
        }
    }
}
