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
                var c1 = chars1[i];
                var c2 = chars2[i];

                if (c1 < ZeroAsciiIndexDecimal || c1 > ZeroAsciiIndexDecimal + 9 ||
                    c2 < ZeroAsciiIndexDecimal || c2 > ZeroAsciiIndexDecimal + 9)
                {
                    throw new InvalidOperationException();
                }

                var d1 = c1 - ZeroAsciiIndexDecimal;
                var d2 = c2 - ZeroAsciiIndexDecimal;

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

        private static List<char> PadNumber(List<char> chars1, int paddingSize)
        {
            var prefix1 = new string('0', paddingSize).ToCharList();
            var paddedChars1 = new List<char>();

            paddedChars1.AddRange(prefix1);
            paddedChars1.AddRange(chars1);

            return paddedChars1;
        }

        private static List<char> ToCharList(this string s)
        {
            return s.ToCharArray().ToList();
        }
    }
}
