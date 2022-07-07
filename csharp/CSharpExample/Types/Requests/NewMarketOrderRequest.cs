namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Ordem a Mercado
    /// </summary>
    public class NewMarketOrderRequest : BaseNewSingleLeggedRequest
    {
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
    }
}