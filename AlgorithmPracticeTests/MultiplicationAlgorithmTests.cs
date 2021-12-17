using System;
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
        public void Multiply_TwoDigitOperands_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("36", "71").Should().Be("2556");
        }

        [Fact]
        public void Multiply_OperandsDifferingByOneDigit_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("7", "71").Should().Be("497");
        }

        [Fact]
        public void Multiply_OperandsDifferingByTwoDigitsBackHeavy_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("7", "100").Should().Be("700");
        }

        [Fact]
        public void Multiply_OperandsDifferingByTwoDigitsFrontHeavy_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("700", "1").Should().Be("700");
        }

        [Fact]
        public void Multiply_ThreeDigitOperands_ReturnsProduct()
        {
            MultiplicationAlgorithm.Multiply("100", "100").Should().Be("10000");
        }

        [Fact]
        public void Multiply_WhenExceedingMaxInteger_DoesNotOverflow()
        {
            MultiplicationAlgorithm.Multiply("99999", "99999").Should().Be("9999800001");
        }

        [Fact]
        public void Multiply_WhenOneZero_ReturnsZero()
        {
            MultiplicationAlgorithm.Multiply("0", "15").Should().Be("0");
        }

        [Fact]
        public void Multiply_WhenTwoZeros_ReturnsZero()
        {
            MultiplicationAlgorithm.Multiply("00", "00").Should().Be("0");
        }

        [Fact]
        public void Multiply_WhenOneFrontNegative_ReturnsNegative()
        {
            MultiplicationAlgorithm.Multiply("-1", "1").Should().Be("-1");
        }

        [Fact]
        public void Multiply_WhenOneBackNegative_ReturnsNegative()
        {
            MultiplicationAlgorithm.Multiply("1", "-1").Should().Be("-1");
        }

        [Fact]
        public void Multiply_WhenDoubleNegative_ReturnsPositive()
        {
            MultiplicationAlgorithm.Multiply("-1", "-1").Should().Be("1");
        }

        [Theory]
        [InlineData("foo", "0")]
        [InlineData("0", "foo")]
        [InlineData("", "1")]
        [InlineData("1", "")]
        [InlineData(null, "1")]
        [InlineData("1", null)]
        public void Multiply_WhenInvalidInput_Throws(string operand1, string operand2)
        {
            Assert.Throws<InvalidOperationException>(() => MultiplicationAlgorithm.Multiply(operand1, operand2));
        }
    }
}
