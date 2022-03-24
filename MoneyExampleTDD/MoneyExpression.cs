using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public interface MoneyExpression
    {
        Money Reduce(Bank bank, string toCurrency);
    }
}
