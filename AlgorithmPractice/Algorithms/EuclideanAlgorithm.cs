using System;

namespace AlgorithmPractice.Algorithms
{
    public static class EuclideanAlgorithm
    {
        public static int ComputeGcd(int a, int b)
        {
            a.ThrowIfNonPositive();
            b.ThrowIfNonPositive();

            var big = Math.Max(a, b);
            var small = Math.Min(a, b);

            var remainder = big % small;

            while (remainder != 0)
            {
                big = small;
                small = remainder;
                remainder = big % small;
            }

            return small;
        }

        private static void ThrowIfNonPositive(this int i)
        {
            if (i < 1)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
