namespace Atividade03.Tests
{
    public class ListAnalyzerTests
    {
        [Fact]
        public void FindMax_WithPositiveNumbers_ReturnsMax()
        {
            var analyzer = new ListAnalyzer();
            int? result = analyzer.FindMax(new List<int> { 1, 2, 3, 4, 5 });
            Assert.Equal(5, result);
        }

        [Fact]
        public void FindMax_WithNegativeNumbers_ReturnsMax()
        {
            var analyzer = new ListAnalyzer();
            int? result = analyzer.FindMax(new List<int> { -1, -2, -3, -4, -5 });
            Assert.Equal(-1, result);
        }

        [Fact]
        public void FindMax_WithEmptyList_ReturnsNull()
        {
            var analyzer = new ListAnalyzer();
            int? result = analyzer.FindMax(new List<int>());
            Assert.Null(result);
        }
    }
}