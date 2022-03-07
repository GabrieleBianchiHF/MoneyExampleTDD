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
            Dollar five = new Dollar(5);

            // ACT ASSERT 1
            five.Times(2).Should().Be(new Dollar(10));

            // ACT ASSERT 2
            five.Times(3).Should().Be(new Dollar(15));
        }

        [Fact]
        public void testEquality()
        {
            Dollar five = new Dollar(5);
            Dollar five2 = new Dollar(5);
            bool fiveEqualsFive = five.Equals(five2);
            bool fiveEqualsSix = five.Equals(new Dollar(6));

            fiveEqualsFive.Should().BeTrue(because: "Are the same");
            fiveEqualsSix.Should().BeFalse(because: "Are different");
        }
    }
}
