namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Hedge Object Update
    /// </summary>
    public class UpdateHedgeInstrument
    {
        /// <summary>
        /// Quantity. It is only possible to change it if the field <i>"QuantityType"</i> is <code>FIXED_QUANTITY</code>
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Hedge Factor (%). <br />
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? Factor { get; set; }

        /// <summary>
        /// Hedge Rounding (%). <br />
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? Rounding { get; set; }
    }

    /// <summary>
    /// Hedge Object Update
    /// </summary>
    public class UpdateParticipativesHegdeInstrument : UpdateHedgeInstrument
    {
        /// <summary>
        ///  Ratio of dynamic limit price of the strategy (A) to the market price of the hedge (B)
        /// </summary>
        public double? LimitRatio { get; set; }

        /// <summary>
        ///  Ratio type, in which: <br />
        ///  <i>A: dynamic limit price of the strategy</i> <br />
        ///  <i>B: market price of the Hedge side</i>
        /// </summary>
        public HedgeLimitRatioType? LimitRatioType { get; set; }
    }
}