namespace ATG.API.Types.Requests.Bases
{
    /// <summary>
    /// Requisição base para atualização das estratégias Participativas (TWAP/VWAP/POV)
    /// </summary>
    public abstract class UpdateParticipativesRequest
    {
        /// <summary>
        /// Quantity
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        public long? MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Maximum participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? MaxParticipation { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        public double? LimitPrice { get; set; }

        /// <summary>
        /// Cross orders traded on the market must be included in the algorithm calculation
        /// </summary>
        public bool? ConsiderCrossVolume { get; set; }

        /// <summary>
        /// Orders outside the limit price must be entered for the algorithm calculation
        /// </summary>
        public bool? ConsiderLimitPrice { get; set; }

        /// <summary>
        /// Defines if the 'IWould' order should be placed or not
        /// </summary>
        public bool? IWouldPlacement { get; set; }

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
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public int? SimultaneousOrders { get; set; }

        /// <summary>
        /// Strategy start time. It is only possible to change if the strategy has not started yet.
        /// HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy end time. HH:mm format
        /// </summary>
        public string? EndTime { get; set; }

        /// <summary>
        /// Strategy Hedge instruments (maximum of three).
        /// </summary>
        public List<UpdateParticipativesHegdeInstrument> Hedge { get; set; }
    }
}
