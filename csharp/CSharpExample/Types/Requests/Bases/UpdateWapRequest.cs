namespace ATG.API.Types.Requests.Bases
{
    /// <summary>
    /// Classe base para atualização das estratégias 'WAP' (TWAP e VWAP)
    /// </summary>
    public abstract class UpdateWapRequest : UpdateParticipativesRequest
    {
        /// <summary>
        /// Minimum display quantity
        /// </summary>
        public long? MinDisplayQuantity { get; set; }

        /// <summary>
        /// Maximum spread
        /// </summary>
        public double? AntiGamingProtection { get; set; }

        /// <summary>
        /// Maximum quantity to be executed as market order.
        /// </summary>
        public long? MaxCrossSize { get; set; }

        /// <summary>
        /// Minimum quantity to be executed as market order.
        /// </summary>
        public long? MinCrossSize { get; set; }
    }
}
