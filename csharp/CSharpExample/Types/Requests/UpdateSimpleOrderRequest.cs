namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Simple Order Update Request
    /// </summary>
    public class UpdateSimpleOrderRequest
    {
        /// <summary>
        /// Quantity to be sent
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Display quantity
        /// </summary>
        public long? DisplayQuantity { get; set; }

        /// <summary>
        /// Order trigger price. Available only if it is a 'Stop'
        /// </summary>
        public double? StopTriggerPrice { get; set; }

        /// <summary>
        /// Order expiration date in yyyy-MM-dd format.
        /// </summary>
        public DateTime? ExpireDate { get; set; }
    }
}