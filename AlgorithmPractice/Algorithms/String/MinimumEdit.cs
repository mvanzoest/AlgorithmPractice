using System;
using AlgorithmPractice.Algorithms.String.Models;

namespace AlgorithmPractice.Algorithms.String
{
    public static class MinimumEdit
    {
        public static MinimumEditResult MinEdit(string s1, string s2)
        {
            s1.ThrowIfNull(nameof(s1));
            s2.ThrowIfNull(nameof(s2));

            var matrix = new int[s1.Length + 1, s2.Length + 1];

            Initialize(matrix, s1, s2);

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    matrix[i, j] = CalculateMin(s1, s2, i, j, matrix);
                }
            }

            var cost = matrix[s1.Length, s2.Length];
            var operations = new MinimumEditOperation[] { };

            var result = new MinimumEditResult(cost, operations);

            return result;
        }

        private static void Initialize(int[,] matrix, string s1, string s2)
        {
            for (var i = 0; i <= s1.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (var j = 0; j <= s2.Length; j++)
            {
                matrix[0, j] = j;
            }
        }

        private static int CalculateMin(string s1, string s2, int i, int j, int[,] matrix)
        {
            var cost = s1[i - 1] == s2[j - 1] ? 0 : 1;

            var replace = matrix[i - 1, j - 1] + cost;
            var remove = matrix[i - 1, j] + 1;
            var insert = matrix[i, j - 1] + 1;

            return Min(replace, remove, insert);
        }

        private static int Min(params int[] values)
        {
            var minimum = int.MaxValue;

            foreach (var value in values)
            {
                if (value < minimum)
                {
                    minimum = value;
                }
            }

            return minimum;
        }

        private static void ThrowIfNull(this string s, string name)
        {
            if (s == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
