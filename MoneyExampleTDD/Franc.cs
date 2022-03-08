using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Franc : Money
    {
        private string _francCurrency;
        public Franc(int amount)
        {
            _amount = amount;
            _francCurrency = "CHF";
        }

        public override string Currency {
            get => _francCurrency;
            set => _francCurrency = value; }

        public override Money Times(int multiplier)
        {
            return new Franc(_amount * multiplier);
        }
    }
}
