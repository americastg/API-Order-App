namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização de Auction Order
    /// </summary>
    public class UpdateAuctionOrderRequest
    {
        public UpdateAuctionOrderRequest()
        { }

        /// <summary>
        /// Quantity
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Price Type
        /// </summary>
        public AuctionPriceType? PriceType { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        public double? LimitPrice { get; set; }

        /// <summary>
        /// Last Price Variation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? LastPriceVariation { get; set; }

        /// <summary>
        /// Participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? Participation { get; set; }

        /// <summary>
        /// 'IWould' price
        /// </summary>
        public double? IWouldPrice { get; set; }

        /// <summary>
        /// 'IWould' quantity
        /// </summary>
        public long? IWouldQuantity { get; set; }
    }
}