namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de um FRA Spread
    /// </summary>
    public class UpdateFRASpreadRequest : Bases.UpdateArbitragesRequest
    {
        public UpdateFRASpreadRequest()
        {
            Instruments = new();
        }
    }
}