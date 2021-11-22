using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Spread.Responses
{
    public class ResponseSpreadInstrument : Requests.NewSpreadInstrument
    {
        public long ExecutedQuantity { get; set; }

        public long DelayedQuantity { get; set; }

        public double AvgPrice { get; set; }
    }

    public class SpreadResponse
    {
        public string StrategyId { get; set; }

        public string User { get; set; }

        public StrategyType StrategyType { get; set; }

        public Status Status { get; set; }

        public string Broker { get; set; }

        public string Account { get; set; }

        public double SpreadValue { get; set; }

        public double MarketSpreadValue { get; set; }

        public double RealizedSpreadValue { get; set; }

        public ValidateSpreadInTheMoney ValidateSpreadInTheMoney { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? StopTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public BalanceMode BalanceMode { get; set; }

        public double SpreadMargin { get; set; }

        public SlippageMode SlippageMode { get; set; }

        public long MaxSlippageQuantity { get; set; }

        public int WaitTime { get; set; }

        public LossCompensation LossCompensation { get; set; }

        public bool ShouldCreateReverseSpreadOnFinish { get; set; }

        public double ReverseSpreadValue { get; set; }

        public List<ResponseSpreadInstrument> Instruments { get; set; }

        public QuantityType QuantityType { get; set; }

        public SpreadType SpreadType { get; set; }

        public DifferentialType DifferentialType { get; set; }

        public bool IsMatchedFinancial { get; set; }
    }
}
