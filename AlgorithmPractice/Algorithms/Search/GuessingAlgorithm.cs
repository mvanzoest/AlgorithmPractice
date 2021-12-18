namespace AlgorithmPractice.Algorithms.Search
{
    public static class GuessingAlgorithm
    {
        /// <summary>
        /// Returns how many log(n) turns it takes to find value in array, or -1 if not found.
        /// </summary>
        public static int Turns(int[] array, int value)
        {
            var startIndex = 0;
            var endIndex = array.Length - 1;
            var turns = 0;

            while (startIndex <= endIndex)
            {
                var middleIndex = (startIndex + endIndex) / 2;

                turns++;

                if (array[middleIndex] == value)
                {
                    return turns;
                }
                else if (array[middleIndex] < value)
                {
                    startIndex = middleIndex + 1;
                }
                else if (array[middleIndex] > value)
                {
                    endIndex = middleIndex;
                }
            }

            return -1;
        }
    }
}
