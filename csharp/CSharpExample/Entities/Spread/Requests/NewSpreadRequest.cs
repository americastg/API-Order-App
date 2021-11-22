using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Spread.Requests
{
    public class NewSpreadInstrument
    {
        #region Required

        public string Symbol { get; set; }

        public Side Side { get; set; }

        public long Quantity { get; set; }

        #endregion Required

        #region Optional

        public string Broker { get; set; }

        public string Account { get; set; }

        public long MaxDisplayQuantity { get; set; }

        public int Depth { get; set; }

        public bool Placement { get; set; }

        public bool AllowExecution { get; set; }

        public short SimultaneousOrders { get; set; }

        public bool PlaceOverBestOffer { get; set; }
        
        public string DeskId { get; set; }

        public string EnteringTrader { get; set; }

        public string Memo { get; set; }

        public string CustomId { get; set; }

        public double PriceFactor { get; set; }

        #endregion Optional
    }

    public class NewSpreadRequest
    {
        #region Required

        public double SpreadValue { get; set; }

        public string EndTime { get; set; }

        public List<NewSpreadInstrument> Instruments { get; set; } = new List<NewSpreadInstrument>();

        #endregion Required

        #region Optional

        public SpreadType SpreadType { get; set; }

        public DifferentialType DifferentialType { get; set; }

        public QuantityType QuantityType { get; set; }

        public bool IsMatchedFinancial { get; set; }

        public string Broker { get; set; }

        public string Account { get; set; }

        public ValidateSpreadInTheMoney ValidateSpreadInTheMoney { get; set; }

        public string StartTime { get; set; }

        public string StopTime { get; set; }

        public BalanceMode BalanceMode { get; set; }

        public double SpreadMargin { get; set; }

        public SlippageMode SlippageMode { get; set; }

        public long MaxSlippageQuantity { get; set; }

        public int WaitTime { get; set; }

        public LossCompensation LossCompensation { get; set; }

        public bool ShouldCreateReverseSpreadOnFinish { get; set; }

        public double ReverseSpreadValue { get; set; }

        #endregion Optional

        public void AddSpreadInstrument(NewSpreadInstrument instrument)
        {
            Instruments.Add(instrument);
        }
    }
}
