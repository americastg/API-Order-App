using System.ComponentModel.DataAnnotations;

namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Iceberg
    /// </summary>
    public class NewIcebergRequest : BaseNewSingleLeggedRequest
    {
        public NewIcebergRequest()
        { }

        /// <summary>
        /// Instrument
        /// </summary>
        [Required]
        public string Symbol { get; set; }

        /// <summary>
        /// Indicates Buy or Sell
        /// </summary>
        [Required]
        public Side Side { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Required]
        public long Quantity { get; set; }

        /// <summary>
        /// Maximum Display Quantity
        /// </summary>
        [Required]
        public long MaxDisplayQuantity { get; set; }

        /// <summary>
        /// Keep Display Quantity
        /// </summary>
        [Required]
        public bool KeepDisplayQuantity { get; set; }

        /// <summary>
        /// Strategy end time.<br />
        /// In the HH:mm format
        /// </summary>
        [Required]
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Number of orders opened simultaneously, maximum 5.
        /// </summary>
        public short SimultaneousOrders { get; set; } = 1;

        /// <summary>
        /// Strategy start time. If not, the strategy starts automatically<br />
        /// HH:mm format
        /// </summary>
        public TimeSpan? StartTime { get; set; }
    }
}