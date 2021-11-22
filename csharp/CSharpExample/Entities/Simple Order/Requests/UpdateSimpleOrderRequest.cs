using System;

namespace Entities.Simple_Order.Requests
{
    public class UpdateSimpleOrderRequest
    {
        public long? Quantity { get; set; }

        public double? Price { get; set; }

        public long? DisplayQuantity { get; set; }

        public double? StopTriggerPrice { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
