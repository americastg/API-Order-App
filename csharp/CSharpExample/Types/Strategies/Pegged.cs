namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Pegged
    /// </summary>
    public class Pegged : SingleLeggedStrategy
    {
        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.PEGGED;

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
        /// Differential price
        /// </summary>
        public double OffsetPrice { get; set; }

        /// <summary>
        /// Validate if it's in the money
        /// </summary>
        public bool ValidateInTheMoney { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        public double LimitPrice { get; set; }

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
        /// Sniper trigger price
        /// </summary>
        public double SniperTriggerPrice { get; set; }

        /// <summary>
        /// Order quantity to be aggressive if the trigger price is reached.
        /// </summary>
        public long SniperMinQuantity { get; set; }

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