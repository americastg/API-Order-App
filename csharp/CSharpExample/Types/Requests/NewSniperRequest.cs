namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Sniper
    /// </summary>
    public class NewSniperRequest : BaseNewSingleLeggedRequest
    {
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
        /// Order trigger price
        /// </summary>
        public double TriggerPrice { get; set; }

        /// <summary>
        /// Strategy end time.<br />
        /// In the HH:mm format
        /// </summary>
        public string? EndTime { get; set; }

        /// <summary>
        /// Quantity type. <i>Default</i>: <code>QUANTITY</code>
        /// </summary>
        public QuantityType QuantityType { get; set; } = QuantityType.QUANTITY;

        /// <summary>
        /// Minimum trigger quantity
        /// </summary>
        public long MinTriggerQuantity { get; set; }

        /// <summary>
        /// Maximum trigger quantity
        /// </summary>
        public long MaxTriggerQuantity { get; set; }

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically<br />
        /// HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy Hedge
        /// </summary>
        public NewHedgeInstrument Hedge { get; set; }
    }
}