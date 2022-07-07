namespace ATG.API.Types.Requests
{
    public class UpdateSpreadInstrument
    {
        /// <summary>
        /// Quantity to be updated
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Quantity to be sent
        /// </summary>
        public long? MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public short? SimultaneousOrders { get; set; }

        /// <summary>
        /// If this leg should place the order. If false, the order will be sent when there is market condition.
        /// </summary>
        public bool? Placement { get; set; }
    }
}
