using System;
using Xunit;
using FluentAssertions;
using MoneyExampleTDD;

namespace MoneyTests
{
    public class MoneyTests
    {

        [Fact]
        public void TestDollarMultiplication()
        {
            // A A A structure
            // ARRANGE
            Money fiveDollars = Money.MakeDollars(5);

            // ACT ASSERT 1
            fiveDollars.Times(2).Should().Be(new Dollar(10));

            // ACT ASSERT 2
            fiveDollars.Times(3).Should().Be(new Dollar(15));
        }

        [Fact]
        public void TestFrancMultiplication()
        {
            // A A A structure
            // ARRANGE
            Franc five = new Franc(5);

            // ACT ASSERT 1
            five.Times(2).Should().Be(new Franc(10));

            // ACT ASSERT 2
            five.Times(3).Should().Be(new Franc(15));
        }

        [Fact]
        public void TestEquality()
        {
            new Dollar(5).Equals(new Dollar(5)).Should().BeTrue(because: "Are the same");
            new Dollar(5).Equals(new Dollar(6)).Should().BeFalse(because: "Are different");
            new Franc(5).Equals(new Franc(5)).Should().BeTrue(because: "Are the same");
            new Franc(5).Equals(new Franc(6)).Should().BeFalse(because: "Are different");
            new Franc(5).Equals(new Dollar(5)).Should().BeFalse(because: "Are different currencies");
        }
    }
}
