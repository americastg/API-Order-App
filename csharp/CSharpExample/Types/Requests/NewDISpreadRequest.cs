using ATG.API.Types.Strategies;

namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de DI Spread
    /// </summary>
    public class NewDISpreadRequest : Bases.NewArbitragesRequest
    {
        /// <summary>
        /// Information about each DI Spread instrument
        /// </summary>
        public new List<DISpreadInstrument> Instruments { get; set; }

        public NewDISpreadRequest()
        {
            Instruments = new();
        }
    }
}