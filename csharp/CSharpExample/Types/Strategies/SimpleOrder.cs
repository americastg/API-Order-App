namespace ATG.API.Types.Strategies
{
    public class SimpleOrder : SingleLeggedStrategy
    {
        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.SIMPLE_ORDER;

        /// <summary>
        /// Order executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }

        /// <summary>
        /// Order sending time
        /// </summary>
        public DateTime SendTime { get; internal set; }

        /// <summary>
        /// Order Start time
        /// </summary>
        public DateTime StartTime { get; internal set; }

        /// <summary>
        /// Tipo da ordem
        /// </summary>
        public SimpleOrderType OrderType { get; internal set; }

        /// <summary>
        /// Order price
        /// </summary>
        public double Price { get; internal set; }

        /// <summary>
        /// Order trigger price, if it is a Stop
        /// </summary>
        public double StopTriggerPrice { get; internal set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }

        /// <summary>
        /// Quantity sent
        /// </summary>
        public long Quantity { get; internal set; }

        /// <summary>
        /// Display quantity
        /// </summary>
        public long DisplayQuantity { get; internal set; }

        /// <summary>
        /// Minimum Quantity
        /// </summary>
        public long MinQuantity { get; internal set; }

        /// <summary>
        /// Indicates Buy or Sell
        /// </summary>
        public Side Side { get; internal set; }

        /// <summary>
        /// Order instrument
        /// </summary>
        public string Symbol { get; internal set; }

        /// <summary>
        /// Validade da ordem
        /// </summary>
        public TimeInForce TimeInForce { get; internal set; }

        /// <summary>
        /// Order expiration date, if the order is GTD
        /// </summary>
        public DateTime ExpireDate { get; set; }
    }
}