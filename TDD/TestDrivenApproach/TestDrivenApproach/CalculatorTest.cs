using Domain;
using FluentAssertions;

namespace TestDrivenApproach
{
    public class CalculatorTest
    {
        [Fact]
        public void Sum_2_and_2_should_be_4() =>
            Calculator.Sum(2,2).Should().Be(4);

    }
}