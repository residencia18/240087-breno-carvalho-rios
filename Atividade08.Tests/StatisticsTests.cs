using Xunit;

namespace Atividade08.Tests;

public class UnitTest1
{
    [Fact]
    public void CalculateAverage_ShouldReturnAverage()
    {
        // Arrange
        var _sut = new Statistics();
        List<int> numbers = new List<int>(){
            1, 2, 3, 4, 5
        };

        // Act
        var result = _sut.CalculateAverage(numbers);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void CalculateAverage_EmptyList_ShouldReturnError()
    {
        // Arrange
        var _sut = new Statistics();
        List<int> numbers = new List<int>();

        // Acc // Assert
        var result = Assert.Throws<ArgumentException>(() => _sut.CalculateAverage(numbers));
        Assert.Contains("The list of numbers cannot be empty", result.Message);
    }

    [Fact]
    public void CalculateAverage_NullList_ShouldReturnError()
    {
        // Arrange
        var _sut = new Statistics();
        List<int>? numbers = null!;

        // Acc // Assert
        var result = Assert.Throws<ArgumentException>(() => _sut.CalculateAverage(numbers));
        Assert.Contains("The list of numbers cannot be empty", result.Message);
    }
}