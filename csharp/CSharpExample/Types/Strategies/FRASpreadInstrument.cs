namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// FRA Spread instrument
    /// </summary>
    public class FRAExecInstrument : Instrument
    {
        /// <summary>
        /// Executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }

        /// <summary>
        /// Delayed quantity
        /// </summary>
        public long DelayedQuantity { get; internal set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }
    }
}