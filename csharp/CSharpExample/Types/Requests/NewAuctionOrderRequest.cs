using System.ComponentModel.DataAnnotations;

namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Auction Order
    /// </summary>
    public class NewAuctionOrderRequest : BaseNewSingleLeggedRequest
    {
        public NewAuctionOrderRequest()
        { }

        /// <summary>
        /// Instrument
        /// </summary>
        [Required]
        public string Symbol { get; set; }

        /// <summary>
        /// Indicates Buy or Sell
        /// </summary>
        [Required]
        public Side Side { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Required]
        public long Quantity { get; set; }

        /// <summary>
        /// Order Type
        /// </summary>
        [Required]
        public AuctionOrderType OrderType { get; set; }

        /// <summary>
        /// Price Type
        /// </summary>
        [Required]
        public AuctionPriceType PriceType { get; set; }

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