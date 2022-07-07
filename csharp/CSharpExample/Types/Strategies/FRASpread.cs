namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Spread FRA
    /// </summary>
    public class FRASpread : Bases.Arbitrages
    {
        /// <summary>
        /// Information about each FRA Spread instrument
        /// </summary>
        public List<FRAExecInstrument> Instruments { get; set; }
    }
}