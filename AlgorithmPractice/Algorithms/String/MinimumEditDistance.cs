namespace AlgorithmPractice.Algorithms.String
{
    public static class MinimumEditDistance
    {
        public static int MinEditDistance(string s1, string s2)
        {
            var matrix = new int[s1.Length + 1, s2.Length + 1];

            for (var i = 0; i <= s1.Length; i++)
            {
                for (var j = 0; j <= s2.Length; j++)
                {
                    if (j == 0)
                    {
                        matrix[i, j] = i;
                    }
                    else if (i == 0)
                    {
                        matrix[i, j] = j;
                    }
                    else
                    {
                        var cost = s1[i - 1] == s2[j - 1] ? 0 : 1;

                        var costs = new[]
                        {
                            matrix[i - 1, j - 1] + cost, // replace
                            matrix[i - 1, j] + 1, // remove
                            matrix[i, j - 1] + 1, // insert
                        };

                        var minimum = int.MaxValue;

                        foreach (var c in costs)
                        {
                            if (c < minimum)
                            {
                                minimum = c;
                            }
                        }

                        matrix[i, j] = minimum;
                    }
                }
            }

            return matrix[s1.Length, s2.Length];
        }
    }
}
