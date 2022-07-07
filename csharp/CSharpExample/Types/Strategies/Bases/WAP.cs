namespace ATG.API.Types.Strategies.Bases
{
    /// <summary>
    /// Classe base para estratégias 'WAP' (TWAP e VWAP)
    /// </summary>
    public abstract class WAP : Participative
    {
        /// <summary>
        /// Maximum spread
        /// </summary>
        public double AntiGamingProtection { get; set; }

        /// <summary>
        /// Minimum display quantity
        /// </summary>
        public long MinDisplayQuantity { get; set; }

        /// <summary>
        /// Maximum quantity to be executed as market order.
        /// </summary>
        public long MaxCrossSize { get; set; }

        /// <summary>
        /// Minimum quantity to be executed as market order.
        /// </summary>
        public long MinCrossSize { get; set; }

        /// <summary>
        /// Minimum waiting time (in seconds) between two aggressive orders
        /// </summary>
        public int SubIntervalDuration { get; set; }
    }
}
