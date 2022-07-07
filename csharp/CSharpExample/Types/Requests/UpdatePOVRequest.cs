namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização do VWAP
    /// </summary>
    public class UpdatePOVRequest : Bases.UpdateParticipativesRequest
    {
        /// <summary>
        /// Minimum participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? MinParticipation { get; set; }

        /// <summary>
        /// Target participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double? TargetParticipation { get; set; }

        public UpdatePOVRequest()
        {
            Hedge = new();
        }
    }
}
