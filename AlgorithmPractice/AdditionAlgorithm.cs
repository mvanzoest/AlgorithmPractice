using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmPractice
{
    public static class AdditionAlgorithm
    {
        private const int ZeroAsciiIndexDecimal = 48;

        /// <summary>
        /// Adds two numbers represented as strings.
        /// </summary>
        public static string Add(string operand1, string operand2)
        {
            var chars1 = operand1.ToCharList();
            var chars2 = operand2.ToCharList();

            if (chars1.Count != chars2.Count)
            {
                chars1 = PadNumber(chars1, Math.Max(chars2.Count - chars1.Count, 0));
                chars2 = PadNumber(chars2, Math.Max(chars1.Count - chars2.Count, 0));
            }

            var carry = 0;

            var sum = new StringBuilder();

            for (var i = chars1.Count - 1; i >= 0; i--)
            {
                var d1 = GetDigit(chars1[i]);
                var d2 = GetDigit(chars2[i]);

                var result = d1 + d2 + carry;
                var digit = result % 10;

                carry = result >= 10 ? 1 : 0;

                sum.Insert(0, digit.ToString());
            }

            if (carry != 0)
            {
                sum.Insert(0, carry.ToString());
            }

            return sum.ToString();
        }

        private static List<char> PadNumber(List<char> chars, int paddingSize)
        {
            var prefix = new string('0', paddingSize).ToCharList();
            var result = new List<char>();

            result.AddRange(prefix);
            result.AddRange(chars);

            return result;
        }

        private static int GetDigit(char c)
        {
            if (c < ZeroAsciiIndexDecimal || c > ZeroAsciiIndexDecimal + 9)
            {
                throw new InvalidOperationException();
            }
            return c - ZeroAsciiIndexDecimal;
        }

        private static List<char> ToCharList(this string s)
        {
            return s.ToCharArray().ToList();
        }
    }
}
