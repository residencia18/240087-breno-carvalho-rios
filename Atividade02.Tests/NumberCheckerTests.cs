namespace Atividade02.Tests
{
    public class NumberCheckerTests
    {
        [Fact]
        public void IsEven_WithEvenNumber_ReturnsTrue()
        {
            var checker = new NumberChecker();
            bool result = checker.IsEven(4);
            Assert.True(result);
        }

        [Fact]
        public void IsEven_WithOddNumber_ReturnsFalse()
        {
            var checker = new NumberChecker();
            bool result = checker.IsEven(5);
            Assert.False(result);
        }

        [Fact]
        public void IsEven_WithZero_ReturnsTrue()
        {
            var checker = new NumberChecker();
            bool result = checker.IsEven(0);
            Assert.True(result);
        }
    }
}