namespace RestApiApp
{
    // Respostas do envio da ordem pela API
    public class TradingResponses
    {
        public long MessageId { get; set; }
        public string StrategyId { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
    }
}