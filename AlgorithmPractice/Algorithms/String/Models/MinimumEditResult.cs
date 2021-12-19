namespace AlgorithmPractice.Algorithms.String.Models
{
    public class MinimumEditResult
    {
        public MinimumEditResult(int cost, string[] operations)
        {
            Cost = cost;
            Operations = operations;
        }
        public int Cost { get; }
        public string[] Operations { get; }
    }

    public enum MinimumEditOperator
    {
        Replace,
        Remove,
        Insert,
    }
}
