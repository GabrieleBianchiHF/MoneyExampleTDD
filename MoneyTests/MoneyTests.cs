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
    }
}
