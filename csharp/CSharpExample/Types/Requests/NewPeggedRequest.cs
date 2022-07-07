namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Pegged
    /// </summary>
    public class NewPeggedRequest : BaseNewSingleLeggedRequest
    {
        /// <summary>
        /// Instrument
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Compra ou venda
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Placement type
        /// </summary>
        public PeggedReferencePriceType ReferencePriceType { get; set; }

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        public long MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Keep Display Quantity
        /// </summary>
        public bool KeepDisplayQuantity { get; set; }

        /// <summary>
        /// Strategy end time.<br />
        /// In the HH:mm format
        /// </summary>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Differential price<br />
        /// Required for <code>BEST_BUY</code> (Best buy) or <code>BEST_SELL</code> (Best sell)
        /// </summary>
        public double OffsetPrice { get; set; }

        /// <summary>
        /// Validate if it's in the money. <i>Default</i>: true<br />
        /// As true: if the strategy is in the money, it will be rejected and some updates may be rejected<br />
        /// As false: if the strategy is in the money, it enters running
        /// </summary>
        public bool ValidateInTheMoney { get; set; } = true;

        /// <summary>
        /// Limit Price
        /// </summary>
        public double LimitPrice { get; set; }

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public short SimultaneousOrders { get; set; } = 1;

        /// <summary>
        /// Sniper trigger price
        /// </summary>
        public double SniperTriggerPrice { get; set; }

        /// <summary>
        /// Order quantitty to be aggressive if the trigger price is reached.
        /// </summary>
        public long SniperMinQuantity { get; set; } = 0;

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically<br />
        /// HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }
    }
}