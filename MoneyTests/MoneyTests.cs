using System;
using Xunit;
using FluentAssertions;
using MoneyExampleTDD;

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
            Money otherFiveDollars = Money.MakeDollars(5);
            
            // ACT
            Money sum = fiveDollars.Plus(otherFiveDollars);

            // ASSERT
            sum.Should().Be(Money.MakeDollars(10));
        }
    }
}
