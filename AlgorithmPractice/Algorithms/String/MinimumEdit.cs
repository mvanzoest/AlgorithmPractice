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

            var m = new int[s1.Length + 1, s2.Length + 1];
            var op = new int[s1.Length + 1, s2.Length + 1];

            Initialize(m, s1, s2);

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    CalculateCosts(s1, s2, i, j, m, op);
                }
            }

            var cost = m[s1.Length, s2.Length];
            var ops = TraceOperations(s1, s2, op, m);

            var result = new MinimumEditResult(cost, ops);

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

        private static void CalculateCosts(string s1, string s2, int i, int j, int[,] m, int[,] op)
        {
            var cost = 1;

            if (s1[i - 1] == s2[j - 1])
            {
                cost = 0;
            }

            var replace = m[i - 1, j - 1] + cost;
            var remove = m[i - 1, j] + 1;
            var insert = m[i, j - 1] + 1;

            var costs = new[] { replace, remove, insert };

            var (value, index) = Min(costs);

            m[i, j] = value;
            op[i, j] = index;
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

        private static void ThrowIfNull(this string s, string name)
        {
            if (s == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
