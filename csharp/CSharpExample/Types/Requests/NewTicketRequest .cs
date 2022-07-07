namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para criação de Ticket
    /// </summary>
    public class NewTicketRequest
    {
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
        /// Target group's ID
        /// </summary>
        public int TargetGroup { get; set; }

        /// <summary>
        /// Broker code at B3
        /// </summary>
        /// É uma string pela possibilidade de uso em bolsas em que o Broker são strings
        public string Broker { get; set; }

        /// <summary>
        /// Sending account
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Ticket execution instructions
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Custom ticket ID
        /// </summary>
        public string CustomId { get; set; }
    }
}