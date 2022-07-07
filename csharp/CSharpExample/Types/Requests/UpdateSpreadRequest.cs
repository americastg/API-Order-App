namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Spread Requests
    /// </summary>
    public class UpdateSpreadRequest : Bases.UpdateArbitragesRequest
    {
        public UpdateSpreadRequest()
        {
            Instruments = new();
        }
    }
}