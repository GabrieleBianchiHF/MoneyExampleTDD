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
            Sum sum = (Sum)moneySource;
            return sum.Reduce(toCurrency);
        }
    }
}
