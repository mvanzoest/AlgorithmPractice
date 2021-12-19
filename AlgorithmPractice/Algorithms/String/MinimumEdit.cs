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

            var costs = new int[s1.Length + 1, s2.Length + 1];
            var operations = new int[s1.Length + 1, s2.Length + 1];

            Initialize(costs, s1, s2);

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    var minCost = 1;

                    if (s1[i - 1] == s2[j - 1])
                    {
                        minCost = 0;
                    }

                    var replace = costs[i - 1, j - 1] + minCost;
                    var remove = costs[i - 1, j] + 1;
                    var insert = costs[i, j - 1] + 1;

                    var localCosts = new [] {replace, remove, insert};
                    var min = Min(localCosts);

                    costs[i, j] = min.Value;
                    operations[i, j] = min.Index;
                }
            }

            var cost = costs[s1.Length, s2.Length];
            var ops = TraceOperations(s1, s2, operations, costs);

            var result = new MinimumEditResult(cost, ops);

            return result;
        }

        private static string[] TraceOperations(string s1, string s2, int[,] operations, int[,] matrix)
        {
            var i = s1.Length;
            var j = s2.Length;

            var ops = new List<string>();

            while (i != 0 || j != 0)
            {
                if (operations[i, j] == (int)MinimumEditOperator.Remove || j == 0)
                {
                    ops.Add($"remove {i - 1}-th char {s1[i - 1]} of {s1}");
                    i -= 1;
                }
                else if (operations[i, j] == (int)MinimumEditOperator.Remove || i == 0)
                {
                    ops.Add($"insert {j - 1}-th char {s2[j - 1]} of {s2}");
                    j -= 1;
                }
                else
                {
                    if (matrix[i - 1, j - 1] < matrix[i, j])
                    {
                        ops.Add($"replace {i - 1}-th char of {s1} ({s1[i - 1]}) with {s2[j - 1]}");
                    }

                    i -= 1;
                    j -= 1;
                }
            }

            return ops.ToArray();
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
