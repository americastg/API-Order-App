using System.Text.Json.Serialization;

namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Iceberg
    /// </summary>
    public class Iceberg : SingleLeggedStrategy
    {
        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.ICEBERG;

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
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public short SimultaneousOrders { get; set; } = 1;

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        public long MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Keep Display Quantity
        /// </summary>
        public bool KeepDisplayQuantity { get; set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }

        /// <summary>
        /// Executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically. HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Strategy end time. HH:mm format
        /// </summary>
        public TimeSpan? EndTime { get; set; }
    }
}