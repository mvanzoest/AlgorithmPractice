namespace AlgorithmPractice.Algorithms
{
    public static class MultiplicationAlgorithm
    {
        public static string Multiply(string factor1, string factor2)
        {
            for (var i = factor2.Length - 1; i >= 0; i--)
            {
                for (var j = factor1.Length - 1; j >= 0; j--)
                {
                    var digit1 = factor1[j];
                    var digit2 = factor2[i];


                }
            }
            var d1 = int.Parse(factor1);
            var d2 = int.Parse(factor2);

            var product = d1 * d2;

            return product.ToString();
        }
    }
}
