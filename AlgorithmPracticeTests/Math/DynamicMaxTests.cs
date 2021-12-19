using System;
using System.Collections.Generic;
using AlgorithmPractice.Algorithms.Math;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.Math
{
    public class DynamicMaxTests
    {
        [Fact]
        public void Max_When2Elements_ReturnsMax()
        {
            var numbers = new List<int> {8, 9};
            DynamicMax.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void Max_When3Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 7, 9 };
            DynamicMax.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void Max_When6Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 9, 7, 2, -1, 2 };
            DynamicMax.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void Max_When7Elements_ReturnsMax()
        {
            var numbers = new List<int> { 8, 9, 7, 2, -1, 0, 2 };
            DynamicMax.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void Max_When1Element_ReturnsMax()
        {
            var numbers = new List<int> { 9 };
            DynamicMax.Max(numbers).Should().Be(9);
        }

        [Fact]
        public void Max_WhenNoElements_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => DynamicMax.Max(new List<int>()));
        }

        [Fact]
        public void Max_WhenNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => DynamicMax.Max(null));
        }
    }
}
