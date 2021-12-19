namespace AlgorithmPractice.Algorithms.String.Models
{
    public class MinimumEditResult
    {
        public MinimumEditResult(int cost, MinimumEditOperation[] operations)
        {
            Cost = cost;
            Operations = operations;
        }
        public int Cost { get; }
        public MinimumEditOperation[] Operations { get; }
    }

    public class MinimumEditOperation
    {
        public MinimumEditOperation(MinimumEditOperator @operator, string value)
        {
            Operator = @operator;
            Value = value;
        }
        public MinimumEditOperator Operator { get; }
        public string Value { get; }
    }

    public enum MinimumEditOperator
    {
        Replace,
        Remove,
        Insert,
    }
}
