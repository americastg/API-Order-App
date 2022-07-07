namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização de Ticket
    /// </summary>
    public class UpdateTicketRequest
    {
        /// <summary>
        /// Quantity
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Ticket execution instructions
        /// </summary>
        public string Instructions { get; set; }
    }
}