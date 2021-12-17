using System;

namespace AlgorithmPractice.Utilities
{
    public static class NumberExtensions
    {
        private const int ZeroAsciiIndexDecimal = 48;

        public static int ToDigit(this char c)
        {
            if (c < ZeroAsciiIndexDecimal || c > ZeroAsciiIndexDecimal + 9)
            {
                throw new InvalidOperationException();
            }
            return c - ZeroAsciiIndexDecimal;
        }
    }
}
