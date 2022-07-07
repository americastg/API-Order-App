namespace ATG.API.Types.Requests
{
    public abstract class BaseNewSingleLeggedRequest
    {
        /// <summary>
        /// Broker code at B3
        /// </summary>
        public virtual string Broker { get; set; }

        /// <summary>
        /// Sending order's account
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// Strategy Desk ID
        /// </summary>
        public string DeskId { get; set; }

        /// <summary>
        /// Strategy entering trader
        /// </summary>
        public string EnteringTrader { get; set; }

        /// <summary>
        /// Strategy memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Strategy Custom ID
        /// </summary>
        public string CustomId { get; set; }
    }
}