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

            // ACT ASSERT 1
            fiveDollars.Times(2).Should().Be(Money.MakeDollars(10));

            // ACT ASSERT 2
            fiveDollars.Times(3).Should().Be(Money.MakeDollars(15));
        }

        [Fact]
        // CAN BE DELETED? WHAT ARE THE TESTED LOGIC?
        public void TestFrancMultiplication()
        {
            // A A A structure
            // ARRANGE
            Money fiveFranc = Money.MakeFrancs(5);

            // ACT ASSERT 1
            fiveFranc.Times(2).Should().Be(Money.MakeFrancs(10));

            // ACT ASSERT 2
            fiveFranc.Times(3).Should().Be(Money.MakeFrancs(15));
        }

        [Fact]
        public void TestEquality()
        {
            Money.MakeDollars(5).Equals(Money.MakeDollars(5)).Should().BeTrue(because: "Are the same");
            Money.MakeDollars(5).Equals(Money.MakeDollars(6)).Should().BeFalse(because: "Are different");
            new Franc(5).Equals(new Franc(5)).Should().BeTrue(because: "Are the same");
            new Franc(5).Equals(new Franc(6)).Should().BeFalse(because: "Are different");
            new Franc(5).Equals(Money.MakeDollars(5)).Should().BeFalse(because: "Are different currencies");
        }
    }
}
