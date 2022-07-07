namespace ATG.API.Types.Requests.Bases
{
    /// <summary>
    /// Requisição base de criação das Arbitragens
    /// </summary>
    public abstract class NewArbitragesRequest
    {
        /// <summary>
        /// Spread Value
        /// </summary>
        public double SpreadValue { get; set; }

        /// <summary>
        /// Strategy end time
        /// HH:mm format
        /// </summary>
        public string? EndTime { get; set; }

        /// <summary>
        /// Broker code at B3. Required if not sent in both spread legs.
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Account to send the order. Mandatory if not sendidng the account in all legs of the strategy.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Validar Spread no dinheiro. <i>Default</i>: <code>NO_CHECK</code> (Não checar)<br />
        /// Ao utilizar este param, se a estratégia estiver no dinheiro, ela não iniciará automaticamente e alguns updates serão rejeitados
        /// </summary>
        public SpreadValidateInTheMoney ValidateSpreadInTheMoney { get; set; } = SpreadValidateInTheMoney.NO_CHECK;

        /// <summary>
        /// Strategy start time. If not sending, the strategy starts automatically<br />
        /// HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy stop time
        /// HH:mm format
        /// </summary>
        public string? StopTime { get; set; }

        /// <summary>
        /// Balanceamento. <i>Default</i>: <code>CONSIDER_MARGIN</code> (Considerar margem)<br />
        /// Caso seja <code>MARKET_ALWAYS</code> (Sempre a mercado), o SpreadMargin, SlippageMode e MaxSlippageQuantity serão ignorados<br />
        /// Caso seja <code>INITIAL_PRICE</code> (Preço Inicial), o SpreadMargin será ignorado
        /// </summary>
        public SpreadBalanceMode BalanceMode { get; set; } = SpreadBalanceMode.CONSIDER_MARGIN;

        /// <summary>
        /// Spread Margin
        /// </summary>
        public double SpreadMargin { get; set; } = 0;

        /// <summary>
        /// Comportamento em caso de encilhamento da estratégia. <i>Default</i>: <code>KEEP_ORDERS</code> (Manter Ordens)
        /// </summary>
        public SpreadSlippageMode SlippageMode { get; set; } = SpreadSlippageMode.KEEP_ORDERS;

        /// <summary>
        /// Maximum slippage quantity
        /// </summary>
        public long MaxSlippageQuantity { get; set; } = 0;

        /// <summary>
        /// Waiting time, in seconds
        /// </summary>
        public int WaitTime { get; set; } = 0;

        /// <summary>
        /// Compensação de perdas. <i>Default</i>: <code>NEVER</code> (Nunca)
        /// </summary>
        public SpreadLossCompensation LossCompensation { get; set; } = SpreadLossCompensation.NEVER;

        /// <summary>
        /// Creates a reverse spread when the strategy ends  . <i>Default</i>: false
        /// </summary>
        public bool ShouldCreateReverseSpreadOnFinish { get; set; } = false;

        /// <summary>
        /// Reverse Spread Value
        /// </summary>
        public double ReverseSpreadValue { get; set; } = 0;
    }
}
