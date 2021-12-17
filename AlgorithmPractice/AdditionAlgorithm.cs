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
            var chars1 = operand1.ToCharArray().ToList();
            var chars2 = operand2.ToCharArray().ToList();

            if (chars1.Count != chars2.Count)
            {
                var prefix1 = new string('0', Math.Max(chars2.Count - chars1.Count, 0)).ToCharArray().ToList();
                var prefix2 = new string('0', Math.Max(chars1.Count - chars2.Count, 0)).ToCharArray().ToList();

                var paddedChars1 = new List<char>();

                paddedChars1.AddRange(prefix1);
                paddedChars1.AddRange(chars1);

                var paddedChars2 = new List<char>();

                paddedChars2.AddRange(prefix2);
                paddedChars2.AddRange(chars2);

                chars1 = paddedChars1;
                chars2 = paddedChars2;

            }

            var carry = 0;

            var sum = new StringBuilder();

            for (var i = chars1.Count - 1; i >= 0; i--)
            {
                var c1 = chars1[i];
                var c2 = chars2[i];

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
    }
}
