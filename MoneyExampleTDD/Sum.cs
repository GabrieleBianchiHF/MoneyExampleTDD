namespace MoneyExampleTDD
{
    public class Sum : MoneyExpression
    {
        public Sum(Money first, Money second)
        {
            First = first;
            Second = second;
        }
        public Money First { get; }
        public Money Second { get; }

        public Money Reduce(string toCurrency)
        {
            int amount = First.Amount + Second.Amount;
            return new Money(amount, toCurrency);
        }
    }
}
