namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Hedge instruments
    /// </summary>
    public class Hedge
    {
        /// <summary>
        /// Broker code at B3
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Account to send the order
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Order instrument
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
        /// Order executed quantity
        /// </summary>
        public long ExecutedQuantity { get; set; }

        /// <summary>
        /// Tipo do Hedge
        /// </summary>
        public HedgeQtyType QuantityType { get; set; }

        /// <summary>
        /// Hedge Factor (%)
        /// </summary>
        public double Factor { get; set; }

        /// <summary>
        /// Hedge Rounding (%)
        /// </summary>
        public double Rounding { get; set; }

        /// <summary>
        /// Hedge average executed price
        /// </summary>
        public double AvgPrice { get; set; }

        /// <summary>
        /// Hedge Desk Id
        /// </summary>
        public string DeskId { get; set; }

        /// <summary>
        /// Hedge Entering Trader
        /// </summary>
        public string EnteringTrader { get; set; }

        /// <summary>
        /// Hedge Memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Hedge Custom Id
        /// </summary>
        public string CustomId { get; set; }
    }

    /// <summary>
    /// Hedge instruments
    /// </summary>
    public class ParticipativesHedge : Hedge
    {
        /// <summary>
        ///  Ratio of dynamic limit price of the strategy (A) to the market price of the hedge (B)
        /// </summary>
        public double LimitRatio { get; set; }

        /// <summary>
        ///  Ratio type, in which: <br />
        ///  <i>A: dynamic limit price of the strategy</i> <br />
        ///  <i>B: market price of the Hedge side</i>
        /// </summary>
        public HedgeLimitRatioType LimitRatioType { get; set; }

        /// <summary>
        /// Executed Ratio
        /// </summary>
        public double ExecutedRatio { get; set; }
    }
}