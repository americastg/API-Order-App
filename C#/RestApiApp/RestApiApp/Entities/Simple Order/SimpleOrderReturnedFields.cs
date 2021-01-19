using Entities.Enums;
using System;

namespace Entities.Simple_Order
{
    public class SimpleOrderReturnedFields : SimpleOrderRequest
    {
        public StrategyType StrategyType { get; set; }
        public long ExecutedQuantity { get; set; }
        public DateTime SendTime { get; set; }
        public double AvgPrice { get; set; }
        public Status Status { get; set; }
        public string StrategyId { get; set; }
    }
}