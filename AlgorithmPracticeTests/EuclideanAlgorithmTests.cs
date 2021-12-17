using System;
using AlgorithmPractice.Algorithms;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests
{
    public class EuclideanAlgorithmTests
    {
        [Fact]
        public void ComputeGcd_When1071And462_Returns21()
        {
            EuclideanAlgorithm.ComputeGcd(1071, 462).Should().Be(21);
        }

        [Fact]
        public void ComputeGcd_When1And1_Returns1()
        {
            EuclideanAlgorithm.ComputeGcd(1, 1).Should().Be(1);
        }

        [Fact]
        public void ComputeGcd_When5And1_Returns1()
        {
            EuclideanAlgorithm.ComputeGcd(5, 1).Should().Be(1);
        }

        [Fact]
        public void ComputeGcd_When3And6_Returns3()
        {
            EuclideanAlgorithm.ComputeGcd(3, 6).Should().Be(3);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(-1, -1)]
        public void ComputeGcd_WhenInvalidInput_Throws(int n1, int n2)
        {
            Assert.Throws<InvalidOperationException>(() => EuclideanAlgorithm.ComputeGcd(n1, n2));
        }
    }
}
