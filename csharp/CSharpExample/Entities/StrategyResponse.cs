namespace Entities
{
    public class StrategyResponse
    {
        public long MessageId { get; set; }
        public string StrategyId { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
    }
}