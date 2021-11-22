using Entities.Enums;
using System;

namespace Entities.Simple_Order.Requests
{
    public class NewSimpleOrderRequest
    {
        #region Required

        public string Broker { get; set; }

        public string Account { get; set; }

        public OrderType OrderType { get; set; }

        public string Symbol { get; set; }

        public Side Side { get; set; }

        public long Quantity { get; set; }

        public TimeInForce TimeInForce { get; set; }

        #endregion

        #region Optional

        public DateTime ExpireDate { get; set; }

        public double Price { get; set; }

        public double StopTriggerPrice { get; set; }

        public long DisplayQuantity { get; set; }

        public long MinQuantity { get; set; }

        public TimeSpan? StartTime { get; set; }

        public string DeskId { get; set; }

        public string EnteringTrader { get; set; }

        public string Memo { get; set; }

        public string CustomId { get; set; }

        #endregion
    }
}
