using AlgorithmPractice.Algorithms.ConvexHull;
using AlgorithmPractice.Algorithms.ConvexHull.Models;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.ConvexHull
{
    public class GrahamsScanTests
    {
        [Fact]
        public void Scan_FindsSimpleConvexHull()
        {
            // Arrange
            var plane = new[]
            {
                // hull points
                new Point(-1, 0),
                new Point(0, 1),
                new Point(1, 0),
                new Point(0, -1),
                // other points
                new Point(-0.5, 0),
                new Point(0, 0.5),
                new Point(0.5, 0),
                new Point(0, -0.5),
            };

            // Act
            var result = GrahamsScan.Scan(plane);

            // Assert
            result.Should<Point>().HaveCount(4);
            for (var i = 0; i < 4; i++)
            {
                result.Should<Point>().Contain(plane[i]);
            }
        }
    }
}
