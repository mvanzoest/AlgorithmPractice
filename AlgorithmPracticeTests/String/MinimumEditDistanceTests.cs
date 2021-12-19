using System;
using AlgorithmPractice.Algorithms.String;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.String
{
    // ReSharper disable StringLiteralTypo
    public class MinimumEditDistanceTests
    {
        [Fact]
        public void MinEditDistance_Chapter3Example_ReturnsThree()
        {
            MinimumEditDistance.MinEditDistance("GCTAC", "CTCA").Should().Be(3);
        }

        [Theory]
        [InlineData(null, "foo")]
        [InlineData("foo", null)]
        public void MinEditDistance_WhenNullInput_Throws(string s1, string s2)
        {
            Assert.Throws<ArgumentNullException>(() =>
                MinimumEditDistance.MinEditDistance(s1, s2));
        }

        [Fact]
        public void MinEditDistance_WhenSameInput_ReturnsZero()
        {
            MinimumEditDistance.MinEditDistance("GCTAC", "GCTAC").Should().Be(0);
        }

        [Fact]
        public void MinEditDistance_WhenEmptyString_ReturnsOtherStringLength()
        {
            MinimumEditDistance.MinEditDistance("GCTAC", "").Should().Be(5);
        }
    }
}
