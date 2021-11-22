using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Spread.Requests
{
    public class UpdateSpreadInstrument
    {
        public long? Quantity { get; set; }

        public long? MaxDisplayQuantity { get; set; }

        public short? SimultaneousOrders { get; set; }

        public bool? Placement { get; set; }
    }

    public class UpdateSpreadRequest
    {
        public List<UpdateSpreadInstrument> Instruments { get; set; } = new List<UpdateSpreadInstrument>();

        public double? SpreadValue { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? StopTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public BalanceMode BalanceMode { get; set; }

        public double? SpreadMargin { get; set; }

        public SlippageMode SlippageMode { get; set; }

        public long? MaxSlippageQuantity { get; set; }

        public int? WaitTime { get; set; }

        public LossCompensation LossCompensation { get; set; }

        public bool? ShouldCreateReverseSpreadOnFinish { get; set; }

        public double? ReverseSpreadValue { get; set; }

        public void AddSpreadInstrument(UpdateSpreadInstrument instrument)
        {
            Instruments.Add(instrument);
        }
    }
}
