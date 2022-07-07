namespace ATG.API.Types.Strategies
{
    public class Ticket : BaseStrategy
    {
        /// <summary>
        /// Status da estratégia
        /// </summary>
        public override StrategyType StrategyType { get; set; } = StrategyType.TICKET;

        /// <summary>
        /// Account to send the order
        /// </summary>
        public string Account { get; internal set; }

        /// <summary>
        /// Broker code at B3
        /// </summary>
        public string Broker { get; internal set; }

        /// <summary>
        /// Instrument
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Compra ou venda
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// Executed quantity
        /// </summary>
        public long ExecutedQuantity { get; internal set; }

        /// <summary>
        /// Assigned Quantity
        /// </summary>
        public long AssignedQuantity { get; internal set; }

        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Average execution price
        /// </summary>
        public double AvgPrice { get; internal set; }

        /// <summary>
        /// Ticket execution instructions
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// ID of the group that received the Ticket
        /// </summary>
        public int TargetGroup { get; set; }

        /// <summary>
        /// Custom ticket ID
        /// </summary>
        public string CustomId { get; set; }

        /// <summary>
        /// Desired quantity, if the attempt to reduce the Ticket quantity is below the quantity reserved in your strategies
        /// </summary>
        public long TryingQuantity { get; set; }
    }
}