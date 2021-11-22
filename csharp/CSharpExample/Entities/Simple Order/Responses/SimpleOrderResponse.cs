using Entities.Enums;
using System;

namespace Entities.Simple_Order.Responses
{
    public class SimpleOrderResponse
    {
        public string Broker { get; set; }

        public string Account { get; set; }

        public string DeskId { get; set; }

        public string EnteringTrader { get; set; }

        public string Memo { get; set; }

        public string CustomId { get; set; }

        public string StrategyId { get; set; }

        public string User { get; set; }

        public StrategyType StrategyType { get; set; }

        public Status Status { get; set; }

        public long ExecutedQuantity { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime StartTime { get; set; }

        public OrderType OrderType { get; set; }

        public double Price { get; set; }

        public double StopTriggerPrice { get; set; }

        public double AvgPrice { get; set; }

        public long Quantity { get; set; }

        public long DisplayQuantity { get; set; }

        public long MinQuantity { get; set; }

        public Side Side { get; set; }

        public string Symbol { get; set; }

        public TimeInForce TimeInForce { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
