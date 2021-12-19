using System;
using System.Collections.Generic;

namespace AlgorithmPractice.Algorithms.Math
{
    public static class Maximum
    {
        /// <summary>
        /// Finds the max in numbers using Divide and Conquer.
        /// </summary>
        public static int Max(List<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Count == 0)
            {
                throw new InvalidOperationException();
            }

            if (numbers.Count == 1)
            {
                return numbers[0];
            }

            var count = numbers.Count / 2;

            var max1 = Max(numbers.GetRange(0, count));
            var max2 = Max(numbers.GetRange(count, numbers.Count - count));

            return max1 > max2 ? max1 : max2;
        }
    }
}
