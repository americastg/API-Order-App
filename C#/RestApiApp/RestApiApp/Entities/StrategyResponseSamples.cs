using System;

namespace RestApiApp
{
    // Respostas para conferir que a ordem enviada confere com a resposta da API
    public class StrategyResponseSamples
    {
        public StrategyType StrategyType { get; set; }
        public string Account { get; set; }
        public string Broker { get; set; }
        public long ExecutedQuantity { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ExpireDate { get; set; }
        public OrderType OrderType { get; set; }
        public double Price { get; set; }
        public double AvgPrice { get; set; }
        public long Quantity { get; set; }
        public long DisplayQuantity { get; set; }
        public long MinQuantity { get; set; }
        public Side Side { get; set; }
        public Status Status { get; set; }
        public string Symbol { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public string StrategyId { get; set; }
    }
}