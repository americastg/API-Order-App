using ATG.API.Types;

namespace ATG.API.Types.Strategies.Bases
{
    /// <summary>
    /// Classe base do Snapshot das Arbitragens
    /// </summary>
    public abstract class Arbitrages : BaseStrategy
    {
        /// <summary>
        /// Broker code in B3. It will be filled with the Broker of the first leg.
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Account to send the order. It will be filled with the account of the first leg.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Spread Value
        /// </summary>
        public double SpreadValue { get; set; }

        /// <summary>
        /// Market spread value
        /// </summary>
        public double MarketSpreadValue { get; set; }

        /// <summary>
        /// Realized spread Value
        /// </summary>
        public double RealizedSpreadValue { get; set; }

        /// <summary>
        /// Validar Spread no dinheiro
        /// </summary>
        public SpreadValidateInTheMoney ValidateSpreadInTheMoney { get; set; }

        /// <summary>
        /// Strategy start time. If not sending, the strategy starts automatically
        /// HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Strategy stop time
        /// </summary>
        public TimeSpan? StopTime { get; set; }

        /// <summary>
        /// Strategy end time
        /// </summary>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Balanceamento. <i>Default</i>: Considerar Margem<br />
        /// Caso seja "Sempre a mercado", a Margem de Spread, Encilhamento e Quantidade máxima encilhada serão ignorados<br />
        /// Caso seja "Preço Inicial", a Margem de Spread será ignorada
        /// </summary>
        public SpreadBalanceMode BalanceMode { get; set; }

        /// <summary>
        /// Spread Margin
        /// </summary>
        public double SpreadMargin { get; set; }

        /// <summary>
        /// Comportamento em caso de encilhamento da estratégia
        /// </summary>
        public SpreadSlippageMode SlippageMode { get; set; }

        /// <summary>
        /// Maximum slippage quantity
        /// </summary>
        public long MaxSlippageQuantity { get; set; }

        /// <summary>
        /// Waiting time, in seconds
        /// </summary>
        public int WaitTime { get; set; }

        /// <summary>
        /// Compensação de perdas
        /// </summary>
        public SpreadLossCompensation LossCompensation { get; set; }

        /// <summary>
        /// Creates a reverse spread when the strategy ends
        /// </summary>
        public bool ShouldCreateReverseSpreadOnFinish { get; set; }

        /// <summary>
        /// Reverse Spread Value
        /// </summary>
        public double ReverseSpreadValue { get; set; }
    }
}
