namespace MoneyExampleTDD
{
    public class Sum : IMoneyExpression
    {
        public Sum(Money first, Money second)
        {
            First = first;
            Second = second;
        }
        public Money First { get; }
        public Money Second { get; }

        public Money Reduce(Bank bank, string toCurrency)
        {
            int amount = First.Reduce(bank, toCurrency).Amount + Second.Reduce(bank, toCurrency).Amount;
            return new Money(amount, toCurrency);
        }
    }
}
