namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Instrumento do Spread
    /// </summary>
    public class SpreadInstrument : Instrument
    {
        /// <summary>
        /// Fator usado como multiplicador no preço. <i>Default</i>: 1<br />
        /// Disponível apenas para SpreadType <code>FACTOR</code> ou DifferentialType <code>VALUE</code>
        /// </summary>
        public double PriceFactor { get; set; } = 1;
    }

    /// <summary>
    /// Instrumento do Spread
    /// </summary>
    public class SpreadExecInstrument : SpreadInstrument
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