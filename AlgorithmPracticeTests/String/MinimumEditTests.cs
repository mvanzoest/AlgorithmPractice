using System;
using AlgorithmPractice.Algorithms.String;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.String
{
    // ReSharper disable StringLiteralTypo
    public class MinimumEditTests
    {
        [Fact]
        public void MinEdit_Chapter3Example_ReturnsThree()
        {
            MinimumEdit.MinEdit("GCTAC", "CTCA").Cost.Should().Be(3);
        }

        [Theory]
        [InlineData(null, "foo")]
        [InlineData("foo", null)]
        public void MinEdit_WhenNullInput_Throws(string s1, string s2)
        {
            Assert.Throws<ArgumentNullException>(() =>
                MinimumEdit.MinEdit(s1, s2));
        }

        [Fact]
        public void MinEdit_WhenSameInput_ReturnsZero()
        {
            MinimumEdit.MinEdit("GCTAC", "GCTAC").Cost.Should().Be(0);
        }

        [Fact]
        public void MinEdit_WhenEmptyString_ReturnsOtherStringLength()
        {
            MinimumEdit.MinEdit("GCTAC", "").Cost.Should().Be(5);
        }

        [Fact]
        public void MinEdit_Chapter3Example_RecordsOperations()
        {
            var expectedOperations = new []
            {
                "replace 4-th char of GCTAC (C) with A",
                "replace 3-th char of GCTAC (A) with C",
                "remove 0-th char G of GCTAC",
            };
            var actualOperations = MinimumEdit.MinEdit("GCTAC", "CTCA").Operations;

            actualOperations.Should<string>().BeEquivalentTo(expectedOperations);
        }
    }
}
