namespace MoneyExampleTDD
{
    public class Money : IMoneyExpression
    {
        private double _amount;
        private string _Currency;

        public Money(double amount, string currency)
        {
            _amount = amount;
            _Currency = currency;
        }

        public string Currency
        {
            get => _Currency;
        }

        public double Amount
        {
            get => _amount;
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return _amount == money._amount && Currency.Equals(money.Currency);
        }


        public static Money MakeDollars(double amount)
        {
            return new Money(amount, "USD");
        }

        public static Money MakeFrancs(double amount)
        {
            return new Money(amount, "CHF");
        }

        public IMoneyExpression Plus(IMoneyExpression addend)
        {
            // Try obvious implementation
            return new Sum(this, addend);
        }

        public IMoneyExpression Times(double multiplier)
        {
            return new Money(_amount * multiplier, Currency);
        }

        public Money Reduce(Bank bank, string toCurrency)
        {
            double rate = bank.GetRate(fromCurrency: Currency, toCurrency: toCurrency);
            return new Money(_amount / rate, toCurrency);     
        }

        public override string ToString()
        {
            return $"{Amount:N2} {Currency}";
        }
    }
}