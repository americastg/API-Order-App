namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de um FRA Inclination
    /// </summary>
    public class UpdateFRAInclinationRequest : Bases.UpdateArbitragesRequest
    {
        public UpdateFRAInclinationRequest()
        {
            Instruments = new();
        }
    }
}