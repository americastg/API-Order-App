using ATG.API.Types.Strategies;

namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de FRA Spread
    /// </summary>
    public class NewFRASpreadRequest : Bases.NewArbitragesRequest
    {
        /// <summary>
        /// Information about each FRA Spread instrument
        /// </summary>
        public new List<Instrument> Instruments { get; set; }

        public NewFRASpreadRequest()
        {
            Instruments = new();
        }
    }
}