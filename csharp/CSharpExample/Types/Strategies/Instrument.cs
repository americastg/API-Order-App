namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Instrument of Spread
    /// </summary>
    public class Instrument
    {
        /// <summary>
        /// Broker code at B3 for this leg. It has priority, if you also send the broker code in strategy body.
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Account to send the order of this leg.  It has priority, if also send the account in strategy body.
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
        /// Maximum Display Quantity
        /// </summary>
        public long MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Limit Depth that the strategy must place the order. Must be between 1 and 5. To send with value "Infinite", send value -1. <i>Default</i>: 1
        /// </summary>
        public int Depth { get; set; } = 1;

        /// <summary>
        /// If this leg should place the order. If false, the order will be sent when there is market condition. <i>Default</i>: true
        /// </summary>
        public bool Placement { get; set; } = true;

        /// <summary>
        /// Whether this leg must execute orders. At least one Strategy Instrument must execute. <i>Default</i>: true
        /// </summary>
        public bool AllowExecution { get; set; } = true;

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5. <i>Default</i>: 1
        /// </summary>
        public short SimultaneousOrders { get; set; } = 1;

        /// <summary>
        /// Best offer. Place an order at the top of the book, covering the best offer, always respecting the target spread. <i>Default</i>: false<br />
        /// Only available if Placement is true. (Placement)<br />
        /// Only available in Double-leg Spreads
        /// </summary>
        public bool PlaceOverBestOffer { get; set; } = false;
        /// <summary>
        /// Strategy Desk ID
        /// </summary>
        public virtual string DeskId { get; set; }

        /// <summary>
        /// Strategy entering trader
        /// </summary>
        public virtual string EnteringTrader { get; set; }

        /// <summary>
        /// Strategy memo
        /// </summary>
        public virtual string Memo { get; set; }

        /// <summary>
        /// Strategy Custom ID
        /// </summary>
        public virtual string CustomId { get; set; }
    }

    /// <summary>
    /// Instrument of Spread
    /// </summary>
    public class ExecInstrument : Instrument
    {
        /// <summary>
        /// Executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }

        /// <summary>
        /// Quantity atrasada
        /// </summary>
        public long DelayedQuantity { get; internal set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }
    }
}