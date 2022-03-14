﻿using System;
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
            return moneySource.Reduce(toCurrency: toCurrency);
        }
    }
}
