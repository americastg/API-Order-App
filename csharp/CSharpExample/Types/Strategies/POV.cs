namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Snapshot do POV
    /// </summary>
    public class POV : Bases.Participative
    {
        /// <summary>
        /// Tipo da Estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.POV;

        /// <summary>
        /// Minimum participation (%)
        /// </summary>
        public double MinParticipation { get; set; }

        /// <summary>
        /// Target participation (%)
        /// </summary>
        public double TargetParticipation { get; set; }

        /// <summary>
        /// Waiting time. In seconds
        /// </summary>
        public int WaitTime { get; set; }
    }
}