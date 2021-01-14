using System;

namespace RestApiApp
{
    // Classe com todos os parâmetros necessários para criação de ordem simples
    // olhar documentação para verificar quais campos são obrigatórios na hora do envio da estratégia
    public class SimpleOrder
    {
        public string Broker { get; set; }
        public string Account { get; set; }
        public OrderType OrderType { get; set; }
        public string Symbol { get; set; }
        public Side Side { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double StopTriggerPrice { get; set; }
        public long DisplayQuantity { get; set; }
        public long MinQuantity { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime ExpireDate { get; set; }
        public string StartTime { get; set; }
    }
}