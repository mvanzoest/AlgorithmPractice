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

        [Fact]
        public void Scan_Chapter1Example_ComputesCorrectly()
        {
            // Arrange
            var plane = new[]
            {
                new Point(0, 0), // 0 - hull
                new Point(1, 10), // 1 - hull
                new Point(2, 4), // 2
                new Point(4, 14), // 3 - hull
                new Point(7, 11), // 4
                new Point(11, 16), // 5 - hull
                new Point(6, -1), // 6
                new Point(14, 12), // 7
                new Point(12, 6), // 8
                new Point(20, 12.25), // 9 - hull
                new Point(18, 3), // 10
                new Point(15.5, -1.25), // 11
                new Point(23, -5), // 12 - hull
                new Point(11.5, -8), // 13 - hull
                new Point(3, -10), // 14 - hull
            };

            // Act
            var result = GrahamsScan.Scan(plane);

            // Assert
            result.Should<Point>().HaveCount(8);

            result.Should<Point>().Contain(plane[0]);
            result.Should<Point>().Contain(plane[1]);
            result.Should<Point>().Contain(plane[3]);
            result.Should<Point>().Contain(plane[5]);
            result.Should<Point>().Contain(plane[9]);
            result.Should<Point>().Contain(plane[12]);
            result.Should<Point>().Contain(plane[13]);
            result.Should<Point>().Contain(plane[14]);
        }
    }
}
