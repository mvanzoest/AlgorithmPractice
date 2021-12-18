using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgorithmPractice.Utilities;

namespace AlgorithmPractice.Algorithms.Math
{
    public static class Addition
    {
        /// <summary>
        /// Adds two numbers represented as strings.
        /// </summary>
        public static string Add(string operand1, string operand2)
        {
            var chars = PadNumbers(GetChars(operand1, operand2));
            var carry = 0;
            var sum = new StringBuilder();

            for (var i = chars.Item1.Count - 1; i >= 0; i--)
            {
                var digits = GetDigits(chars, i);
                var result = digits.Item1 + digits.Item2 + carry;
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

        private static (List<char>, List<char>) GetChars(string o1, string o2)
        {
            return (o1.ToCharList(), o2.ToCharList());
        }

        private static (List<char>, List<char>) PadNumbers((List<char>, List<char>) chars)
        {
            if (chars.Item1.Count != chars.Item2.Count)
            {
                chars.Item1 = PadNumber(chars.Item1, System.Math.Max(chars.Item2.Count - chars.Item1.Count, 0));
                chars.Item2 = PadNumber(chars.Item2, System.Math.Max(chars.Item1.Count - chars.Item2.Count, 0));
            }

            return chars;
        }

        private static List<char> PadNumber(List<char> chars, int paddingSize)
        {
            var prefix = new string('0', paddingSize).ToCharList();
            var result = new List<char>();

            result.AddRange(prefix);
            result.AddRange(chars);

            return result;
        }

        private static (int, int) GetDigits((List<char>, List<char>) chars, int index)
        {
            var d1 = chars.Item1[index].ToDigit();
            var d2 = chars.Item2[index].ToDigit();

            return (d1, d2);
        }

        private static List<char> ToCharList(this string s)
        {
            return s.ToCharArray().ToList();
        }
    }
}
