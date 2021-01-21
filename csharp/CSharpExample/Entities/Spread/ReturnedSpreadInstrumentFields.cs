namespace Entities.Spread
{
    // Campos referentes ao instrumento do spread, que retornados pela API ao fazer uma consulta dos spreads (requisição GET)
    public class ReturnedSpreadInstrumentFields : SpreadInstrument
    {
        public long ExecutedQuantity { get; set; }
        public long DelayedQuantity { get; set; }
        public double AvgPrice { get; set; }
    }
}