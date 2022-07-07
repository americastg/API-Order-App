namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização de Iceberg
    /// </summary>
    public class UpdateIcebergRequest
    {
        public UpdateIcebergRequest()
        { }

        /// <summary>
        /// Quantity
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double? Price { get; set; }

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
        /// Strategy start time. It is only possible to change if the strategy has not started yet.
        /// HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Strategy end time. HH:mm format
        /// </summary>
        public TimeSpan? EndTime { get; set; }
    }
}