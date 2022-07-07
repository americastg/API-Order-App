namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização de Sniper
    /// </summary>
    public class UpdateSniperRequest
    {
        /// <summary>
        /// Quantity
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Minimum trigger quantity
        /// </summary>
        public long? MinTriggerQuantity { get; set; }

        /// <summary>
        /// Maximum trigger quantity
        /// </summary>
        public long? MaxTriggerQuantity { get; set; }

        /// <summary>
        /// Sniper trigger
        /// </summary>
        public double? TriggerPrice { get; set; }

        /// <summary>
        /// Strategy start time. It is only possible to change if the strategy has not started yet.
        /// HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy end time..<br />
        /// In the HH:mm format
        /// </summary>
        public string? EndTime { get; set; }

        /// <summary>
        /// Strategy Hedge instruments (maximum of three).
        /// </summary>
        public UpdateHedgeInstrument Hedge { get; set; }
    }
}