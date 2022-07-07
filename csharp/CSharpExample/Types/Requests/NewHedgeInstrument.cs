namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Strategy Hedge instruments (maximum of three).
    /// </summary>
    public class NewHedgeInstrument
    {
        /// <summary>
        /// Broker code at B3. <i>Default</i>: Broker code filled in the strategy
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Account to send the order. <i>Default</i>: Account filled in the strategy
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Order instrument
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Indicates Buy or Sell
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        /// Hedge Rounding (%). <br />
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double Rounding { get; set; }

        /// <summary>
        /// Hedge Quantity type. <i>Default</i>: <code>FINANCIAL_FACTOR</code> (Fator Financeiro)
        /// </summary>
        public HedgeQtyType QuantityType { get; set; } = HedgeQtyType.FINANCIAL_FACTOR;

        /// <summary>
        /// Quantity. Mandatory field if <i>QuantityType</i> is <code>FIXED_QUANTITY</code> (Fixed Quantity)
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Hedge Factor (%). Mandatory field if <i>QuantityType</i> is <code>FINANCIAL_FACTOR</code> (Financial Factor). <br />
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? Factor { get; set; }

        /// <summary>
        /// Hedge Desk Id
        /// </summary>
        public string DeskId { get; set; }

        /// <summary>
        /// Hedge Entering Trader
        /// </summary>
        public string EnteringTrader { get; set; }

        /// <summary>
        /// Hedge Memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Hedge Custom Id
        /// </summary>
        public string CustomId { get; set; }
    }

    /// <summary>
    /// Strategy Hedge instruments (maximum of three).
    /// </summary>
    public class NewParticipativesHegdeInstrument : NewHedgeInstrument
    {
        /// <summary>
        ///  Ratio of dynamic limit price of the strategy (A) to the market price of the hedge (B)
        ///  Mandatory if <i>LimitRatioType</i> is NOT <code>NONE</code>
        /// </summary>
        public double LimitRatio { get; set; }

        /// <summary>
        ///  Ratio type, in which: <br />
        ///  <i>A: dynamic limit price of the strategy</i> <br />
        ///  <i>B: market price of the Hedge side</i>
        /// <i>Default</i>: <code>NONE</code>
        /// </summary>
        public HedgeLimitRatioType LimitRatioType { get; set; } = HedgeLimitRatioType.NONE;
    }
}