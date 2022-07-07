namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Auction Order
    /// </summary>
    public class AuctionOrder : SingleLeggedStrategy
    {
        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.AUCTION_ORDER;

        /// <summary>
        /// Instrument
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Indicates Buy or Sell
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Order Type
        /// </summary>
        public AuctionOrderType OrderType { get; set; }

        /// <summary>
        /// Price Type
        /// </summary>
        public AuctionPriceType PriceType { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        public double? LimitPrice { get; set; }

        /// <summary>
        /// Last Price Variation (%)
        /// </summary>
        public double? LastPriceVariation { get; set; }

        /// <summary>
        /// Participation (%)
        /// </summary>
        public double Participation { get; set; }

        /// <summary>
        /// Realized Participation (%)
        /// </summary>
        public double RealizedParticipation { get; set; }

        /// <summary>
        /// 'IWould' price
        /// </summary>
        public double? IWouldPrice { get; set; }

        /// <summary>
        /// 'IWould' quantity
        /// </summary>
        public long? IWouldQuantity { get; set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }

        /// <summary>
        /// Executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }
    }
}