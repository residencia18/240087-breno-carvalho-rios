using Xunit;

namespace Atividade06.Tests;

public class PointTests
{
    [Fact]
    public void DistanceTo_ReturnsDistance()
    {
        // Arrange
        double X1 = 1.5;
        double Y1 = 2.3;
        
        double X2 = 1.2;
        double Y2 = 2.0;

        var point1 = new Point(X1, Y1);
        var point2 = new Point(X2, Y2);
        
        // Act
        var expected = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
        var result = point1.DistanceTo(point2);
        
        // Assert        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DistanceTo_NullPoint_ShouldReturnsError()
    {
        // Arrange
        double X1 = 1.5;
        double Y1 = 2.3;

        var point1 = new Point(X1, Y1);
        Point? point2 = null;
        
        // Act // Assert
        var result = Assert.Throws<ArgumentNullException>(() => point1.DistanceTo(point2!));
        Assert.Contains("Argument must be a Point", result.Message);
    }
}