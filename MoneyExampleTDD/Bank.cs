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
            if (moneySource is Money)
                return moneySource as Money;
            else
            {
                return (moneySource as Sum).Reduce(toCurrency);
            }
        }
    }
}
