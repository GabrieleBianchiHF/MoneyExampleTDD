﻿namespace MoneyExampleTDD
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
            int amount = First.Amount + Second.Amount;
            return new Money(amount, toCurrency);
        }
    }
}
