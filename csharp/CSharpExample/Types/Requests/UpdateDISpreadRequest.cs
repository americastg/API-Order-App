namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de um DI Spread
    /// </summary>
    public class UpdateDISpreadRequest : Bases.UpdateArbitragesRequest
    { 
        public UpdateDISpreadRequest()
        {
            Instruments = new();
        }
    }
}