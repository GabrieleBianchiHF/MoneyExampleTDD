using FluentAssertions;
using MoneyExampleTDD;
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
            MoneyExpression sum = fiveDollars.Plus(otherFiveDollars);
            Money reduced = bank.Reduce(sum, "USD");

            // ASSERT
            reduced.Should().Be(Money.MakeDollars(11));
        }

        [Fact]
        public void TestPlusReturnsSum()
        {
            Money fiveDollar = Money.MakeDollars(5);

            MoneyExpression result = fiveDollar.Plus(fiveDollar);
            Sum sum = (result as Sum);

            fiveDollar.Should().Be(sum.First);
            fiveDollar.Should().Be(sum.Second);
        }

        [Fact]
        public void TestReduceSum()
        {
            MoneyExpression sum = new Sum(Money.MakeDollars(3), Money.MakeDollars(4));
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
            bank.addRate("CHF", "USD", 2);

            Money result = bank.Reduce(Money.MakeFrancs(2), "USD");

            result.Should().Be(Money.MakeDollars(1));
        }
  
    }
}