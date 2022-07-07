namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de POV
    /// </summary>
    public class NewPOVRequest : Bases.NewParticipativesRequest
    {
        /// <summary>
        /// Minimum participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double MinParticipation { get; set; }

        /// <summary>
        /// Maximum participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public new double MaxParticipation { get; set; }

        /// <summary>
        /// Target participation (%)
        /// Only values ​​between 0 and 1 are allowed. <i>Ex: <code>0.1</code> it's the same as<code>10%</code></i>
        /// </summary>
        public double TargetParticipation { get; set; }

        /// <summary>
        /// Waiting time. In seconds
        /// </summary>
        public int? WaitTime { get; set; }
    }
}
