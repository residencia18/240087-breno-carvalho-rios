using System.Drawing;

namespace Atividade06.Tests
{
    public class PointTests
    {
        [Fact]
        public void DistanceTo_SamePoint_ReturnsZero()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(0, 0);
            Assert.Equal(0, p1.DistanceTo(p2));
        }

        [Fact]
        public void DistanceTo_DifferentPoint_ReturnsCorrectDistance()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(3, 4);
            Assert.Equal(5, p1.DistanceTo(p2));
        }

        [Fact]
        public void DistanceTo_NullPoint_ThrowsArgumentNullException()
        {
            var p1 = new Point(0, 0);
            Assert.Throws<ArgumentNullException>(() => p1.DistanceTo(null));
        }
    }
}