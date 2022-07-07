namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Spread DI
    /// </summary>
    public class DISpread : Bases.Arbitrages
    {
        /// <summary>
        /// Information about each DI Spread instrument
        /// </summary>
        public List<DISpreadExecInstrument> Instruments { get; set; }
    }
}