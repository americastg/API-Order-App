namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Simple Order Request
    /// </summary>
    public class NewSimpleOrderRequest : BaseNewSingleLeggedRequest
    {
        /// <summary>
        /// Tipo da ordem<br />
        /// Ao enviar TimeInForce <code>MOC</code> ou <code>MOA</code>, este campo será ignorado e enviado como <code>MARKET</code>
        /// </summary>
        public SimpleOrderType OrderType { get; set; }

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
        /// Validade da ordem
        /// </summary>
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Order expiration date in yyyy-MM-dd format.
        /// Required for orders with TimeInForce <code>GTD</code>
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Price.
        /// Required for orders with OrderType <code>LIMIT</code>
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Order trigger price, if it is a Stop
        /// </summary>
        public double StopTriggerPrice { get; set; }

        /// <summary>
        /// Display quantity
        /// </summary>
        public long DisplayQuantity { get; set; }

        /// <summary>
        /// Minimum Quantity
        /// </summary>
        public long MinQuantity { get; set; }

        /// <summary>
        /// Order sending time to B3, in the HH:mm format
        /// </summary>
        public string? StartTime { get; set; }
    }
}