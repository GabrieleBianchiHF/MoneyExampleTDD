using FluentAssertions;
using MoneyExampleTDD;
using System;
using Xunit;

namespace MoneyTests
{
    public class MoneyTests
    {
        [Fact]
        public void TestMultiplication()
        {
            // A A A structure
            // ARRANGE
            Money fiveDollars = Money.MakeDollars(5);
            Money fiveFrancs = Money.MakeFrancs(5);

            // ACT ASSERT 1
            fiveDollars.Times(2).Should().Be(Money.MakeDollars(10));
            fiveFrancs.Times(2).Should().Be(Money.MakeFrancs(10));

            // ACT ASSERT 2
            fiveDollars.Times(3).Should().Be(Money.MakeDollars(15));
            fiveFrancs.Times(3).Should().Be(Money.MakeFrancs(15));
        }

        [Fact]
        public void TestEquality()
        {
            Money.MakeDollars(5).Equals(Money.MakeDollars(5)).Should().BeTrue(because: "Are the same amounts");
            Money.MakeDollars(5).Equals(Money.MakeDollars(6)).Should().BeFalse(because: "Are different amounts");
            Money.MakeFrancs(5).Equals(Money.MakeDollars(5)).Should().BeFalse(because: "Are different currencies");
        }

        [Fact]
        public void TestCurrency()
        {
            string dollarCurrency = "USD";
            string francCurrency = "CHF";
            Money oneDollar = Money.MakeDollars(1);
            Money oneFranc = Money.MakeFrancs(1);

            oneDollar.Currency.Should().BeEquivalentTo(dollarCurrency);
            oneFranc.Currency.Should().BeEquivalentTo(francCurrency);
        }

        [Fact]
        public void TestSimpleAddition()
        {
            // ARRANGE
            Money fiveDollars = Money.MakeDollars(5);
            Money otherFiveDollars = Money.MakeDollars(6);
            Bank bank = new Bank();

            // ACT
            IMoneyExpression sum = fiveDollars.Plus(otherFiveDollars);
            Money reduced = bank.Reduce(sum, "USD");

            // ASSERT
            reduced.Should().Be(Money.MakeDollars(11));
        }

        [Fact]
        public void TestPlusReturnsSum()
        {
            Money fiveDollar = Money.MakeDollars(5);

            IMoneyExpression result = fiveDollar.Plus(fiveDollar);
            Sum sum = (result as Sum);

            fiveDollar.Should().Be(sum.First);
            fiveDollar.Should().Be(sum.Second);
        }

        [Fact]
        public void TestReduceSum()
        {
            IMoneyExpression sum = new Sum(Money.MakeDollars(3), Money.MakeDollars(4));
            Bank bank = new Bank();

            Money result = bank.Reduce(sum, "USD");
            result.Should().Be(Money.MakeDollars(7));
        }

        [Fact]
        public void TestReduceMoney()
        {
            Bank bank = new Bank();
            Money oneDollar = Money.MakeDollars(1);
            Money result = bank.Reduce(oneDollar, oneDollar.Currency);

            result.Should().Be(oneDollar);
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Money result = bank.Reduce(Money.MakeFrancs(2), "USD");

            result.Should().Be(Money.MakeDollars(1));
        }

        [Fact ]
        public void TestTupleEquals()
        {
            Tuple<string, string> currencies1 = new("USD", "CHF");
            Tuple<string, string> currencies2 = new("USD", "CHF");

            currencies1.Should().Be(currencies2);
        }

        [Fact]
        public void TestRateSameCurrency()
        {
            Bank bank = new Bank();

            double rate = bank.GetRate("USD", "USD");

            rate.Should().Be(1);
        }

        [Fact]
        public void TestMixedCurrenciesAddition()
        {
            IMoneyExpression fiveDollars = Money.MakeDollars(5);
            IMoneyExpression tenFrancs = Money.MakeFrancs(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Money result = bank.Reduce(fiveDollars.Plus(tenFrancs), "USD");
            result.Should().Be(Money.MakeDollars(10));
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            IMoneyExpression fiveDollars = Money.MakeDollars(5);
            IMoneyExpression tenFrancs = Money.MakeFrancs(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            IMoneyExpression sum = new Sum(fiveDollars, tenFrancs).Plus(fiveDollars);
            Money result = bank.Reduce(sum, "USD");
            result.Should().Be(Money.MakeDollars(15));
        }

        [Fact]
        public void TestMultiplicationWithDoubles()
        {
            // A A A structure
            // ARRANGE
            Money fiveDollars = Money.MakeDollars(5.5);
            Money fiveFrancs = Money.MakeFrancs(5.5);

            // ACT ASSERT 1
            fiveDollars.Times(2.0).Should().Be(Money.MakeDollars(11.0));
            fiveFrancs.Times(2.0).Should().Be(Money.MakeFrancs(11.0));

            // ACT ASSERT 2
            fiveDollars.Times(3).Should().Be(Money.MakeDollars(16.5));
            fiveFrancs.Times(3).Should().Be(Money.MakeFrancs(16.5));
        }

        [Fact]
        public void TestInverseRate()
        {
            Money oneDollar = Money.MakeDollars(1);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Money someFrancs = bank.Reduce(oneDollar, "CHF");
            Money result = bank.Reduce(someFrancs, "USD");

            result.Should().Be(oneDollar);
        }

        [Fact]
        public void TestMoneyToString()
        {
            Money oneDollar = Money.MakeDollars(1);

            string result = oneDollar.ToString();

            result.Should().Be("1.00 USD");
        }
    }
}