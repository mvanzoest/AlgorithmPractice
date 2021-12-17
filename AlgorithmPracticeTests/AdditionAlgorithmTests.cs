using System;
using AlgorithmPractice;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests
{
    public class AdditionAlgorithmTests
    {
        [Fact]
        public void Add_Adds4To3_Returns7()
        {
            AdditionAlgorithm.Add("4", "3").Should().Be("7");
        }

        [Fact]
        public void Add_Adds4To7_Returns11()
        {
            AdditionAlgorithm.Add("4", "7").Should().Be("11");
        }

        [Fact]
        public void Add_Adds14To23_Returns37()
        {
            AdditionAlgorithm.Add("14", "23").Should().Be("37");
        }

        [Fact]
        public void Add_Adds59To89_Returns148()
        {
            AdditionAlgorithm.Add("59", "89").Should().Be("148");
        }

        [Fact]
        public void Add_Adds7To11_Returns18()
        {
            AdditionAlgorithm.Add("7", "11").Should().Be("18");
        }

        [Fact]
        public void Add_WhenInvalidOperand1_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => AdditionAlgorithm.Add("foo", "1"));
        }

        [Fact]
        public void Add_WhenInvalidOperand2_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => AdditionAlgorithm.Add("1", "foo"));
        }

        // Note: negative numbers must be represented by a subtraction algorithm.
    }
}
