namespace ATG.API.Types
{
    /// <summary>
    /// Reply to Simple Order or Strategy Requests
    /// </summary>
    public class StrategyResponse
    {
        /// <summary>
        /// Message identifier in internal services, used for tracking
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Strategy Id. Used for update or cancellation
        /// </summary>
        public string StrategyId { get; set; }

        /// <summary>
        /// Whether the request was successfully executed. If false, the Error field will be filled.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// If it fails, the error will come in this field
        /// </summary>
        public string Error { get; set; }
    }
}