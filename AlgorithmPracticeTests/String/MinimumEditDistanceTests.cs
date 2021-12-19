using AlgorithmPractice.Algorithms.String;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.String
{
    public class MinimumEditDistanceTests
    {
        [Fact]
        public void MinEditDistance_Chapter3Example_ReturnsThree()
        {
            // ReSharper disable StringLiteralTypo
            MinimumEditDistance.MinEditDistance("GCTAC", "CTCA").Should().Be(3);
        }
    }
}
