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

        [Fact]
        public void Multiply_2DigitOperands_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("36", "71").Should().Be("2556");
        }

        [Fact]
        public void Multiply_OperandsDifferingBy1Digit_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("7", "71").Should().Be("497");
        }

        [Fact]
        public void Multiply_OperandsDifferingBy2DigitsBackHeavy_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("7", "100").Should().Be("700");
        }

        [Fact]
        public void Multiply_OperandsDifferingBy2DigitsFrontHeavy_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("700", "1").Should().Be("700");
        }
    }
}
