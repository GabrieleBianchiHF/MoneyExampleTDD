namespace MoneyExampleTDD
{
    public class Sum : IMoneyExpression
    {
        public Sum(IMoneyExpression first, IMoneyExpression second)
        {
            First = first;
            Second = second;
        }
        public IMoneyExpression First { get; }
        public IMoneyExpression Second { get; }

        public IMoneyExpression Plus(IMoneyExpression addend)
        {
            return new Sum(this, addend);
        }

        public IMoneyExpression Times(double multiplier)
        {
            return new Sum(First.Times(multiplier), Second.Times(multiplier));
        }

        public Money Reduce(Bank bank, string toCurrency)
        {
            double amount = First.Reduce(bank, toCurrency).Amount + Second.Reduce(bank, toCurrency).Amount;
            return new Money(amount, toCurrency);
        }

        public override string ToString()
        {
            return $"{First} + {Second}";
        }
    }
}
