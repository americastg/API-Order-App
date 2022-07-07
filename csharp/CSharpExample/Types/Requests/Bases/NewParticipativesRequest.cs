namespace ATG.API.Types.Requests.Bases
{
    /// <summary>
    /// Requisição base das estratégias Participativas (TWAP/VWAP/POV)
    /// </summary>
    public abstract class NewParticipativesRequest : BaseNewSingleLeggedRequest
    {
        /// <summary>
        /// Strategy instrument
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
        /// Strategy end time. HH:mm format
        /// </summary>
        public string? EndTime { get; set; }

        /// <summary>
        /// Quantity type. <i>Default</i>: <code>QUANTITY</code>
        /// </summary>
        public QuantityType QuantityType { get; set; } = QuantityType.QUANTITY;

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        public long? MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Maximum participation (%) <br />
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i> <br />
        /// <i>Default</i>: <code>1</code> (100%)
        /// </summary>
        public double? MaxParticipation { get; set; } = 1.0;

        /// <summary>
        /// Cross orders traded on the market must be included in the algorithm calculation. <i>Default</i>: false
        /// </summary>
        public bool ConsiderCrossVolume { get; set; } = false;

        /// <summary>
        /// Orders above the limit price must be included into the calculation of the algorithm. <i>Default</i>: false
        /// </summary>
        public bool ConsiderLimitPrice { get; set; } = false;

        /// <summary>
        /// Limit Price
        /// </summary>
        public double? LimitPrice { get; set; }

        /// <summary>
        /// 'IWould' price
        /// </summary>
        public double? IWouldPrice { get; set; }

        /// <summary>
        /// 'IWould' quantity
        /// </summary>
        public long? IWouldQuantity { get; set; }

        /// <summary>
        /// Display quantity 'IWould'
        /// </summary>
        public long? IWouldDisplayQuantity { get; set; }

        /// <summary>
        /// Defines if the 'IWould' order should be placed or not. <i>Default</i>: true
        /// </summary>
        public bool IWouldPlacement { get; set; } = true;

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5. <i>Default</i>: 1
        /// </summary>
        public short SimultaneousOrders { get; set; } = 1;

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically. HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy Hedge instruments (maximum of three).
        /// </summary>
        public List<NewParticipativesHegdeInstrument> Hedges { get; set; }
    }
}
