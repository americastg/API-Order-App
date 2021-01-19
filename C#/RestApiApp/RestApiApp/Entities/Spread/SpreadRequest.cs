using System.Collections.Generic;
using Entities.Enums;

namespace Entities.Spread
{
    // Campos usados para a inclusão/update de spread
    public class SpreadRequest
    {
        #region required fields

        public string Broker { get; set; }
        public string Account { get; set; }
        public double SpreadValue { get; set; }
        public SpreadType SpreadType { get; set; }
        public DifferentialType DifferentialType { get; set; }
        public string EndTime { get; set; }
        public List<SpreadInstrument> Instruments { get; set; } = new List<SpreadInstrument>();

        #endregion required fields

        #region optional fields

        public bool? IsMatchedFinancial { get; set; }
        public ValidateSpreadInTheMoney? ValidateSpreadInTheMoney { get; set; }
        public QuantityType? QuantityType { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public BalanceMode? BalanceMode { get; set; }
        public double? SpreadMargin { get; set; }
        public SlippageMode? SlippageMode { get; set; }
        public long? MaxSlippageQuantity { get; set; }
        public int? WaitTime { get; set; }
        public LossCompensation? LossCompensation { get; set; }
        public bool? ShouldCreateReverseSpreadOnFinish { get; set; }
        public double? ReverseSpreadValue { get; set; }

        #endregion optional fields

        public void AddSpreadInstrument(SpreadInstrument instrument)
        {
            Instruments.Add(instrument);
        }
    }
}