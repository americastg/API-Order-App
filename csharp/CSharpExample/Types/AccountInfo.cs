namespace ATG.API.Types
{
    /// <summary>
    /// Account Info
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// Account to send the order
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Account Alias 
        /// </summary>
        public string AccountAlias { get; set; }

        /// <summary>
        /// Broker code at B3
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Internal broker name
        /// </summary>
        public string BrokerName { get; set; }

        /// <summary>
        /// Exchange ID at B3
        /// </summary>
        public string ExchangeId { get; set; }


    }

}
