namespace ATG.API.Types
{
    public class Trade
    {
        /// <summary>
        /// Trade ID on ATG. Used as a filter when searching for trades.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Broker code at B3
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }

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
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product used on sending order
        /// </summary>
        /// <example>MTB, ATG.API</example>
        public string Product { get; set; }

        /// <summary>
        /// Simple Order or Strategy ID that originated the trade
        /// </summary>
        public string StrategyID { get; set; }

        /// <summary>
        /// Time that the trade occurred
        /// </summary>
        public DateTime TradeDate { get; set; }

        /// <summary>
        /// Trade ID on B3.
        /// </summary>
        public string ExchangeTradeId { get; set; }

        /// <summary>
        /// User who submitted the Order or Strategy
        /// </summary>
        public string User { get; set; }
    }
}