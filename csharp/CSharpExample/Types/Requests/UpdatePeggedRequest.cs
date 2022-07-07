namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização de Pegged
    /// </summary>
    public class UpdatePeggedRequest
    {
        /// <summary>
        /// Quantity
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Differential price<br />
        /// Required for <code>BEST_BUY</code> (Best buy) or <code>BEST_SELL</code> (Best sell)
        /// </summary>
        public double? OffsetPrice { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        public double? LimitPrice { get; set; }

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public short? SimultaneousOrders { get; set; }

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        public long? MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Keep Display Quantity
        /// </summary>
        public bool? KeepDisplayQuantity { get; set; }

        /// <summary>
        /// Sniper trigger price
        /// </summary>
        public double? SniperTriggerPrice { get; set; }

        /// <summary>
        /// Order quantity to be aggressive if the trigger price is reached.
        /// </summary>
        public long? SniperMinQuantity { get; set; }

        /// <summary>
        /// Strategy start time. It is only possible to change if the strategy has not started yet.
        /// HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy end time. HH:mm format
        /// </summary>
        public string? EndTime { get; set; }
    }
}