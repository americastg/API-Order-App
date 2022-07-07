namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Spread
    /// </summary>
    public class Spread : Bases.Arbitrages
    {
        /// <summary>
        /// Information about each Spread instrument
        /// </summary>
        public List<SpreadExecInstrument> Instruments { get; set; }

        /// <summary>
        /// Quantity type
        /// </summary>
        public QuantityType QuantityType { get; set; }

        /// <summary>
        /// Tipo do spread
        /// </summary>
        public SpreadType SpreadType { get; set; }

        /// <summary>
        /// Tipo de diferencial
        /// </summary>
        public SpreadDifferentialType DifferentialType { get; set; }

        /// <summary>
        /// Matched Financial
        /// </summary>
        public bool IsMatchedFinancial { get; set; }
    }
}