using AlgorithmPractice.Algorithms;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests
{
    public class MultiplicationAlgorithmTests
    {
        [Fact]
        public void Multiply_2Times3_Returns6()
        {
            MultiplicationAlgorithm.Multiply("2", "3").Should().Be("6");
        }

        [Fact]
        public void Multiply_10Times10_Returns100()
        {
            MultiplicationAlgorithm.Multiply("10", "10").Should().Be("100");
        }
    }
}
