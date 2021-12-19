using System;
using System.Collections.Generic;
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
            var operations = new int[s1.Length + 1, s2.Length + 1];

            Initialize(matrix, s1, s2);

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    var minCost = 1;

                    if (s1[i - 1] == s2[j - 1])
                    {
                        minCost = 0;
                    }

                    var replace = matrix[i - 1, j - 1] + minCost;
                    var remove = matrix[i - 1, j] + 1;
                    var insert = matrix[i, j - 1] + 1;

                    var costs = new int[] {replace, remove, insert};
                    var min = Min(costs);

                    matrix[i, j] = min.Value;
                    operations[i, j] = min.Index;
                }
            }

            var cost = matrix[s1.Length, s2.Length];

            var currentI = s1.Length;
            var currentJ = s2.Length;

            var ops = new List<string>();

            while (currentI != 0 || currentJ != 0)
            {
                if (operations[currentI, currentJ] == (int) MinimumEditOperator.Remove || currentJ == 0)
                {
                    ops.Add($"remove {currentI - 1}-th char {s1[currentI - 1]} of {s1}");
                    currentI -= 1;
                }
                else if (operations[currentI, currentJ] == (int) MinimumEditOperator.Remove || currentI == 0)
                {
                    ops.Add($"insert {currentJ - 1}-th char {s2[currentJ - 1]} of {s2}");
                    currentJ -= 1;
                }
                else
                {
                    if (matrix[currentI - 1, currentJ - 1] < matrix[currentI, currentJ])
                    {
                        ops.Add($"replace {currentI - 1}-th char of {s1} ({s1[currentI - 1]}) with {s2[currentJ - 1]}");
                    }

                    currentI -= 1;
                    currentJ -= 1;
                }
            }

            var result = new MinimumEditResult(cost, ops.ToArray());

            return result;
        }

        private static void Initialize(int[,] matrix, string s1, string s2)
        {
            matrix[0, 0] = 0;

            for (var i = 1; i <= s1.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (var j = 1; j <= s2.Length; j++)
            {
                matrix[0, j] = j;
            }
        }

        private static (int Value, int Index) Min(int[] values)
        {
            var value = int.MaxValue;
            var index = int.MaxValue;

            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] < value)
                {
                    value = values[i];
                    index = i;
                }
            }

            return (value, index);
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
