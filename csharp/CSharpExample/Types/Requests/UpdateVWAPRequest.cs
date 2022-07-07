namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização do VWAP
    /// </summary>
    public class UpdateVWAPRequest : Bases.UpdateWapRequest
    {
        public UpdateVWAPRequest()
        {
            Hedge = new();
        }
    }
}
