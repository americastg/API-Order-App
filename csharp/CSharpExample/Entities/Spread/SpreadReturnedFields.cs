using System.Collections.Generic;
using Entities.Enums;

namespace Entities.Spread
{
    // Campos retornados pela API ao fazer uma consulta dos spreads (requisição GET)
    public class SpreadReturnedFields : SpreadRequest
    {
        public StrategyType StrategyType { get; set; }
        public Status Status { get; set; }
        public double MarketSpreadValue { get; set; }
        public double RealizedSpreadValue { get; set; }
        public string StrategyId { get; set; }
        public new List<ReturnedSpreadInstrumentFields> Instruments { get; set; } = new List<ReturnedSpreadInstrumentFields>();
    }
}