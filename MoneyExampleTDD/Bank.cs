using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Bank
    {
        private readonly Dictionary<Tuple<string, string>, int> _Rates = new Dictionary<Tuple<string, string>, int>();

        public Money Reduce(IMoneyExpression moneySource, string toCurrency)
        {
            return moneySource.Reduce(this, toCurrency: toCurrency);
        }

        public int GetRate(string fromCurrency, string toCurrency)
        {
            if (_Rates.TryGetValue(new Tuple<string, string>(fromCurrency, toCurrency), out int rate))
                return rate;
            else if (fromCurrency.Equals(toCurrency))
                return 1;
            else
                throw new InvalidOperationException("The required from/to key is not present.");
        }

        public void AddRate(string fromCurrency, string toCurrency, int rate)
        {
            _Rates.Add(key: new Tuple<string,string>(fromCurrency, toCurrency),
                       value: rate);
        }
    }
}
