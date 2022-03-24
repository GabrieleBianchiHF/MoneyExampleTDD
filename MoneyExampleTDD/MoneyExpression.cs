using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public interface IMoneyExpression
    {
        Money Reduce(Bank bank, string toCurrency);

        IMoneyExpression Plus(IMoneyExpression addend);

        IMoneyExpression Times(double multiplier);
    }
}
