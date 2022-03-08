using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Franc : Money
    {
        private string _Currency;

        public Franc(int amount)
        {
            _amount = amount;
            _Currency = "CHF";
        }

        public override string Currency {
            get => _Currency;
            set => _Currency = value; }

        public override Money Times(int multiplier)
        {
            return new Franc(_amount * multiplier);
        }
    }
}
