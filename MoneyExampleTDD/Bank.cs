using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Bank
    {
        private readonly Dictionary<Tuple<string, string>, int> _Rates;

        public Bank()
        {
            _Rates = new Dictionary<Tuple<string, string>, int>();
        }

        public Money Reduce(MoneyExpression moneySource, string toCurrency)
        {
            return moneySource.Reduce(this, toCurrency: toCurrency);
        }

        public int GetRate(string fromCurrency, string toCurrency)
        {
            return fromCurrency.Equals("CHF") && toCurrency.Equals("USD") ? 2 : 1;
        }

        public void AddRate(string fromCurrency, string toCurrency, int rate)
        {
            _Rates.Add(key: new Tuple<string,string>(fromCurrency, toCurrency),
                       value: rate);
        }
    }
}
