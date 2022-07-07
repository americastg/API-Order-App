namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do VWAP
    /// </summary>
    public class VWAP : Bases.WAP
    {
        /// <summary>
        /// Tipo da Estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.VWAP;
    }
}
