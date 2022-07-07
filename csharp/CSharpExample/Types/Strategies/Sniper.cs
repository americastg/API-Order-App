namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Sniper
    /// </summary>
    public class Sniper : SingleLeggedStrategy
    {
        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.SNIPER;

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
        /// Quantity type
        /// </summary>
        public QuantityType QuantityType { get; set; }

        /// <summary>
        /// Minimum trigger quantity
        /// </summary>
        public long MinTriggerQuantity { get; set; }

        /// <summary>
        /// Maximum trigger quantity
        /// </summary>
        public long MaxTriggerQuantity { get; set; }

        /// <summary>
        /// Order trigger price
        /// </summary>
        public double TriggerPrice { get; set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; set; }

        /// <summary>
        /// Executed quantity
        /// </summary>
        public long ExecutedQuantity { get; set; }

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically. HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Strategy end time. HH:mm format
        /// </summary>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Strategy Hedge
        /// </summary>
        public HedgeInstrument Hedge { get; set; }
    }
}