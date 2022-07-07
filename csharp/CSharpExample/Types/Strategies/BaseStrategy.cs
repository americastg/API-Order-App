namespace ATG.API.Types.Strategies
{
    /// <summary>
    /// Strategy snapshot
    /// </summary>
    public abstract class BaseStrategy
    {
        /// <summary>
        /// Strategy identifier
        /// </summary>
        public virtual string StrategyId { get; set; }

        /// <summary>
        /// User who sent the strategy
        /// </summary>
        public virtual string User { get; set; }

        /// <summary>
        /// Tipo da estratégia
        /// </summary>
        public virtual StrategyType StrategyType { get; set; }

        /// <summary>
        /// Status da estratégia
        /// </summary>
        public virtual StrategyStatus Status { get; set; }
    }

    public class BaseTest : BaseStrategy
    {
        public BaseTest() { }
    }

    public abstract class SingleLeggedStrategy : BaseStrategy
    {
        /// <summary>
        /// Broker code at B3
        /// </summary>
        public virtual string Broker { get; set; }

        /// <summary>
        /// Sending account
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// Strategy Desk ID
        /// </summary>
        public virtual string DeskId { get; set; }

        /// <summary>
        /// Strategy entering trader
        /// </summary>
        public virtual string EnteringTrader { get; set; }

        /// <summary>
        /// Strategy memo
        /// </summary>
        public virtual string Memo { get; set; }

        /// <summary>
        /// Strategy Custom ID
        /// </summary>
        public virtual string CustomId { get; set; }
    }
}