using Atividade01;
using Xunit.Sdk;

namespace Atividade01.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            int result = calculator.Add(2, 3);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_NegativeAndPositive_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            int result = calculator.Add(-1, 1);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_TwoNegativeNumbers_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            int result = calculator.Add(-1, -1);
            Assert.Equal(-2, result);
        }
    }
}