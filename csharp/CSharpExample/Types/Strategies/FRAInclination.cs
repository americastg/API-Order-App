namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do Inclination FRA
    /// </summary>
    public class FRAInclination : Bases.Arbitrages
    {
        /// <summary>
        /// Information about each FRA Inclination instrument
        /// </summary>
        public List<FRAExecInstrument> Instruments { get; set; }
    }
}