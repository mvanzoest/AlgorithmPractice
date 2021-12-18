using System;
using AlgorithmPractice.Algorithms.Math;
using FluentAssertions;
using Xunit;

namespace AlgorithmPracticeTests.Math
{
    public class AdditionTests
    {
        [Fact]
        public void Add_Adds4To3_Returns7()
        {
            Addition.Add("4", "3").Should().Be("7");
        }

        [Fact]
        public void Add_Adds4To7_Returns11()
        {
            Addition.Add("4", "7").Should().Be("11");
        }

        [Fact]
        public void Add_Adds14To23_Returns37()
        {
            Addition.Add("14", "23").Should().Be("37");
        }

        [Fact]
        public void Add_Adds59To89_Returns148()
        {
            Addition.Add("59", "89").Should().Be("148");
        }

        [Fact]
        public void Add_Adds7To11_Returns18()
        {
            Addition.Add("7", "11").Should().Be("18");
        }

        [Fact]
        public void Add_Adds11To7_Returns18()
        {
            Addition.Add("11", "7").Should().Be("18");
        }

        [Fact]
        public void Add_WhenInvalidOperand1_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Addition.Add("foo", "1"));
        }

        [Fact]
        public void Add_WhenInvalidOperand2_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Addition.Add("1", "foo"));
        }

        [Fact]
        public void Add_AddsTwoLargeNumbers_ReturnsSum()
        {
            var op1 = "354534250504";
            var op2 = "789345923452";
            var sum = "1143880173956";

            Addition.Add(op1, op2).Should().Be(sum);
        }

        // Note: negative numbers must be represented by a subtraction algorithm.
    }
}
