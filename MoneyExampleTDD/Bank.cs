using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Bank
    {
        public Money Reduce(MoneyExpression moneySource, string toCurrency)
        {
            return moneySource.Reduce(this, toCurrency: toCurrency);
        }

        public int GetRate(string fromCurrency, string toCurrency)
        {
            return fromCurrency.Equals("CHF") && toCurrency.Equals("USD") ? 2 : 1;
        }
    }
}
