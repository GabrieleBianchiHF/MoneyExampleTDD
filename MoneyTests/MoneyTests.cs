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

            // ACT
            five.Times(2);

            // ASSERT
            five.amount.Should().Be(10);
        }

        [Fact]
        public void TestMultiplication2()
        {
            // A A A structure
            // ARRANGE
            Dollar five = new Dollar(5);

            // ACT 1
            Dollar product = five.Times(2);
            // ASSERT 1
            product.amount.Should().Be(10);

            // ACT 2
            product.Times(3);
            // ASSERT 
            product.amount.Should().Be(15);
            ;
        }
    }
}
