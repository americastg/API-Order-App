namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do TWAP
    /// </summary>
    public class TWAP : Bases.WAP
    {
        /// <summary>
        /// Tipo da Estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.TWAP;
    }
}
