namespace Atividade04.Tests
{
    public class NumberSorterTests
    {
        [Fact]
        public void SortNumbers_WithUnsortedList_ReturnsSorted()
        {
            var sorter = new NumberSorter();
            var result = sorter.SortNumbers(new List<int> { 3, 1, 2 });
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void SortNumbers_WithMixedList_ReturnsSorted()
        {
            var sorter = new NumberSorter();
            var result = sorter.SortNumbers(new List<int> { 5, 3, 1, 4, 2 });
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void SortNumbers_WithEmptyList_ReturnsEmpty()
        {
            var sorter = new NumberSorter();
            var result = sorter.SortNumbers(new List<int>());
            Assert.Empty(result);
        }
    }
}