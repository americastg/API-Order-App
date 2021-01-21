using Entities.Enums;
using System;

namespace Entities.SimpleOrder
{
    // Classe com todos os parâmetros para criação de ordem simples
    public class SimpleOrderRequest
    {
        #region required fields

        public string Broker { get; set; }
        public string Account { get; set; }
        public OrderType OrderType { get; set; }
        public string Symbol { get; set; }
        public Side Side { get; set; }
        public long Quantity { get; set; }
        public TimeInForce TimeInForce { get; set; }

        #endregion required fields

        #region optional fields

        public DateTime ExpireDate { get; set; }
        public double Price { get; set; }
        public double StopTriggerPrice { get; set; }
        public long DisplayQuantity { get; set; }
        public long MinQuantity { get; set; }
        public string StartTime { get; set; }

        #endregion optional fields
    }
}