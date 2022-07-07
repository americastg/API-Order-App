namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// DI Spread instrument
    /// </summary>
    public class DISpreadInstrument : Instrument
    {
        /// <summary>
        /// Factor as a price multiplier.<br />
        /// In case it is not filled, <i>system's default</i> will be used.<br />
        /// For more information about <i>default</i> contact ETS:<br />
        /// <a href="mailto:ets@americastg.com">ets@americastg.com</a>
        /// </summary>
        public double? PriceFactor { get; set; }
    }

    /// <summary>
    /// DI Spread Instrument
    /// </summary>
    public class DISpreadExecInstrument : DISpreadInstrument
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