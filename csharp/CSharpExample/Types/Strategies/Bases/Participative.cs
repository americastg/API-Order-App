namespace ATG.API.Types.Strategies.Bases
{
    /// <summary>
    /// Classe base do Snapshot das estratégias Participativas (TWAP/VWAP/POV)
    /// </summary>
    public abstract class Participative : SingleLeggedStrategy
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
        /// Quantity sent
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Order executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }

        /// <summary>
        /// Quantity Type
        /// </summary>
        public QuantityType QuantityType { get; set; }

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        public long MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Maximum participation (%)
        /// </summary>
        public double MaxParticipation { get; set; }

        /// <summary>
        /// Realized participation (%)
        /// </summary>
        public double RealizedParticipation { get; set; }

        /// <summary>
        /// Cross orders traded on the market must be included in the algorithm calculation
        /// </summary>
        public bool ConsiderCrossVolume { get; set; }

        /// <summary>
        /// Orders outside the limit price must be entered for the algorithm calculation
        /// </summary>
        public bool ConsiderLimitPrice { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        public double LimitPrice { get; set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }

        /// <summary>
        /// 'IWould' price
        /// </summary>
        public double IWouldPrice { get; set; }

        /// <summary>
        /// 'IWould' quantity
        /// </summary>
        public long IWouldQuantity { get; set; }

        /// <summary>
        /// Display quantity 'IWould'
        /// </summary>
        public long IWouldDisplayQuantity { get; set; }

        /// <summary>
        /// Defines if the 'IWould' order should be placed or not
        /// </summary>
        public bool IWouldPlacement { get; set; }

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public int SimultaneousOrders { get; set; }

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically. HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Strategy end time. HH:mm format
        /// </summary>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Hedges of the strategy
        /// </summary>
        public List<ParticipativesHedge> Hedges { get; set; }
    }
}