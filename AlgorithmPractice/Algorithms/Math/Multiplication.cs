using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmPractice.Utilities;

namespace AlgorithmPractice.Algorithms.Math
{
    public static class Multiplication
    {
        /// <summary>
        /// Multiplies two numbers represented as strings.
        /// </summary>
        public static string Multiply(string topFactor, string bottomFactor)
        {
            topFactor.ThrowIfNullOrEmpty();
            bottomFactor.ThrowIfNullOrEmpty();

            var sign = 1;

            ComputeSign(ref topFactor, ref sign);
            ComputeSign(ref bottomFactor, ref sign);

            var subProducts = new List<string>();

            for (var i = bottomFactor.Length - 1; i >= 0; i--)
            {
                var start = new string('0', bottomFactor.Length - (i + 1));
                var subProduct = new StringBuilder(start);
                var carry = 0;

                for (var j = topFactor.Length - 1; j >= 0; j--)
                {
                    var bottomDigit = bottomFactor[i].ToDigit();
                    var topDigit = topFactor[j].ToDigit();

                    var innerProduct = bottomDigit * topDigit + carry;
                    var result = innerProduct % 10;

                    carry = innerProduct / 10;

                    subProduct.Insert(0, result.ToString());
                }

                if (carry > 0)
                {
                    subProduct.Insert(0, carry.ToString());
                }

                subProducts.Add(subProduct.ToString());
            }

            var product = BuildProduct(subProducts, sign);

            return product;
        }

        private static void ComputeSign(ref string factor, ref int sign)
        {
            if (factor.StartsWith("-"))
            {
                sign *= -1;
                factor = factor.Substring(1);
            }
        }

        private static string BuildProduct(List<string> subProducts, int sign)
        {
            var subProductSum = AddSubProducts(subProducts);
            var trimmedProduct = TrimLeadingZeros(subProductSum);
            var signedProduct = (sign < 0 ? "-" : "") + trimmedProduct;

            return signedProduct;
        }

        private static string AddSubProducts(List<string> subProducts)
        {
            var product = "0";

            foreach (var subProduct in subProducts)
            {
                product = Addition.Add(product, subProduct);
            }

            return product;
        }

        private static string TrimLeadingZeros(string product)
        {
            var chars = product.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[0] == '0' && i != chars.Length - 1)
                {
                    product = product.Substring(1);
                }
            }

            return product;
        }

        private static void ThrowIfNullOrEmpty(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
