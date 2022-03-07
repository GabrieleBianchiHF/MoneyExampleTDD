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

            // ACT 1
            Dollar product = five.Times(2);
            // ASSERT 1
            product.amount.Should().Be(10);

            // ACT 2
            product = five.Times(3);
            // ASSERT 
            product.amount.Should().Be(15);
            ;
        }

        [Fact]
        public void testEquality()
        {
            Dollar five = new Dollar(5);
            Dollar five2 = new Dollar(5);
            bool areEquals = five.Equals(five2);

            areEquals.Should().BeTrue("Are the same");

        }
    }
}
