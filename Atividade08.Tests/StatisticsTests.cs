namespace Atividade08.Tests
{
    public class StatisticsTests
    {
        [Fact]
        public void CalculateAverage_WithNumbers_ReturnsAverage()
        {
            var stats = new Statistics();
            double result = stats.CalculateAverage(new List<int> { 1, 2, 3, 4, 5 });
            Assert.Equal(3, result);
        }

        [Fact]
        public void CalculateAverage_WithEmptyList_ThrowsArgumentException()
        {
            var stats = new Statistics();
            Assert.Throws<ArgumentException>(() => stats.CalculateAverage(new List<int>()));
        }
    }
}