﻿using System.Collections.Generic;
using System.Text;
using AlgorithmPractice.Utilities;

namespace AlgorithmPractice.Algorithms
{
    public static class MultiplicationAlgorithm
    {
        public static string Multiply(string factor1, string factor2)
        {
            var subProducts = new List<string>();

            for (var i = factor2.Length - 1; i >= 0; i--)
            {
                var start = new string('0', factor2.Length - (i + 1));
                var subProduct = new StringBuilder(start);
                var carry = 0;

                for (var j = factor1.Length - 1; j >= 0; j--)
                {
                    var digit1 = factor1[j].ToDigit();
                    var digit2 = factor2[i].ToDigit();

                    var innerProduct = digit1 * digit2 + carry;
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

            var product = "0";

            foreach (var subProduct in subProducts)
            {
                product = AdditionAlgorithm.Add(product, subProduct);
            }

            return product;
        }
    }
}
