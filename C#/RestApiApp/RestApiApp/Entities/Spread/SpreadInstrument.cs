using Entities.Enums;

namespace Entities.Spread
{
    // Campos usados para a inclusão/update de instrumentos do spread
    public class SpreadInstrument
    {
        #region required fields

        public string Symbol { get; set; }
        public Side Side { get; set; }
        public long Quantity { get; set; }
        public long MaxDisplayQuantity { get; set; }

        #endregion required fields

        #region optional fields

        public int? Depth { get; set; }
        public bool? Placement { get; set; }
        public bool? AllowExecution { get; set; }
        public double? PriceFactor { get; set; }
        public int? SimultaneousOrders { get; set; }
        public bool? PlaceOverBestOffer { get; set; }

        #endregion optional fields
    }
}