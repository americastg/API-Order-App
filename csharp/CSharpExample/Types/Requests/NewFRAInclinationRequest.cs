using ATG.API.Types.Strategies;

namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Inclinação de FRA
    /// </summary>
    public class NewFRAInclinationRequest : Bases.NewArbitragesRequest
    {
        /// <summary>
        /// Information about each FRA Inclination instrument
        /// </summary>
        public new List<Instrument> Instruments { get; set; }

        public NewFRAInclinationRequest()
        {
            Instruments = new();
        }
    }
}