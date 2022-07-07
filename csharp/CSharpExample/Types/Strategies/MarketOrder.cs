namespace ATG.API.Types.Strategies
{
    public class MarketOrder : SingleLeggedStrategy
    {
        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.MARKET_ORDER;

        /// <summary>
        /// Order executed quantity
        /// </summary>
        public long ExecutedQuantity { get; set; }

        /// <summary>
        /// Order sending time
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; set; }

        /// <summary>
        /// Quantity to be sent
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Indicates Buy or Sell
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        /// Order instrument
        /// </summary>
        public string Symbol { get; set; }
    }
}