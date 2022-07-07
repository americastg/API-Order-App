using ATG.API.Types;

namespace ATG.API.Types.Requests.Bases
{
    /// <summary>
    /// Requisição base para atualização das Arbitragens
    /// </summary>
    public abstract class UpdateArbitragesRequest
    {
        /// <summary>
        /// Information about each Spread instrument
        /// </summary>
        public List<UpdateSpreadInstrument> Instruments { get; set; }

        /// <summary>
        /// Spread Value
        /// </summary>
        public double? SpreadValue { get; set; }

        /// <summary>
        /// Strategy start time. It is only possible to change if the strategy has not started yet.
        /// HH:mm format
        /// </summary>
        public string? StartTime { get; set; }

        /// <summary>
        /// Strategy stop time
        /// HH:mm format
        /// </summary>
        public string? StopTime { get; set; }

        /// <summary>
        /// Strategy end time
        /// HH:mm format
        /// </summary>
        public string? EndTime { get; set; }

        /// <summary>
        /// Balanceamento. <i>Default</i>: <code>CONSIDER_MARGIN</code> (Considerar margem)<br />
        /// Caso seja <code>MARKET_ALWAYS</code> (Sempre a mercado), o SpreadMargin, SlippageMode e MaxSlippageQuantity serão ignorados<br />
        /// Caso seja <code>INITIAL_PRICE</code> (Preço Inicial), o SpreadMargin será ignorado
        /// </summary>
        public SpreadBalanceMode BalanceMode { get; set; } = SpreadBalanceMode.NONE;

        /// <summary>
        /// Spread Margin
        /// </summary>
        public double? SpreadMargin { get; set; }

        /// <summary>
        /// Comportamento em caso de encilhamento da estratégia
        /// </summary>
        public SpreadSlippageMode SlippageMode { get; set; } = SpreadSlippageMode.NONE;

        /// <summary>
        /// Maximum slippage quantity
        /// </summary>
        public long? MaxSlippageQuantity { get; set; }

        /// <summary>
        /// Waiting time, in seconds
        /// </summary>
        public int? WaitTime { get; set; }

        /// <summary>
        /// Compensação de perdas
        /// </summary>
        public SpreadLossCompensation LossCompensation { get; set; } = SpreadLossCompensation.NONE;

        /// <summary>
        /// Creates a reverse spread when the strategy ends
        /// </summary>
        public bool? ShouldCreateReverseSpreadOnFinish { get; set; }

        /// <summary>
        /// Reverse Spread Value
        /// </summary>
        public double? ReverseSpreadValue { get; set; }
    }
}