using System.Linq;
using AlgorithmPractice;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests
{
    public class GuessingAlgorithmTests
    {
        [Fact]
        public void Turns_WhenMiddleValue_Returns1()
        {
            var array = new [] { 1, 2, 3 };
            var value = 2;

            var result = GuessingAlgorithm.Turns(array, value);

            result.Should().Be(1);
        }

        [Fact]
        public void Turns_WhenUpperMiddleValue_Returns2()
        {
            var array = new [] { 1, 2, 3, 4 };
            var value = 3;

            var result = GuessingAlgorithm.Turns(array, value);

            result.Should().Be(2);
        }

        [Fact]
        public void Turns_WhenHighValueOf4_Returns3()
        {
            var array = new [] { 1, 2, 3, 4 };
            var value = 4;

            var result = GuessingAlgorithm.Turns(array, value);

            result.Should().Be(3);
        }

        [Fact]
        public void Turns_WhenLowValueOf4_Returns2()
        {
            var array = new[] { 1, 2, 3, 4 };
            var value = 1;

            var result = GuessingAlgorithm.Turns(array, value);

            result.Should().Be(2);
        }

        [Fact]
        public void Turns_WhenValueNotFound_ReturnsNegative1()
        {
            var array = new[] { 1, 2, 3 };
            var value = 4;

            var result = GuessingAlgorithm.Turns(array, value);

            result.Should().Be(-1);
        }

        [Fact]
        public void Turns_WhenOf1000Find867_Returns2()
        {
            var array = Enumerable.Range(1, 1000).ToArray();
            var value = 867;

            var result = GuessingAlgorithm.Turns(array, value);

            // 500, 750, 875, 812, 844, 860, 868, 864, 866, 867

            result.Should().Be(10);
        }
    }
}
