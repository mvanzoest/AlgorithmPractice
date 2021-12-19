using System;
using System.Collections.Generic;
using AlgorithmPractice.Algorithms.Math;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.Math
{
    public class MaximumTests
    {
        [Fact]
        public void FindMax_When2Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 9 };
            Maximum.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void FindMax_When3Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 7, 9 };
            Maximum.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void FindMax_When6Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 9, 7, 2, -1, 2 };
            Maximum.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void FindMax_When7Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 9, 7, 2, -1, 0, 2 };
            Maximum.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void FindMax_When1Element_ReturnsMax()
        {
            var numbers = new List<int> { 9 };
            Maximum.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void FindMax_WhenNoElements_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Maximum.Max(new List<int>()));
        }

        [Fact]
        public void FindMax_WhenNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Maximum.Max(null));
        }
    }
}
