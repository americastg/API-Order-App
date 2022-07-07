namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição para atualização do TWAP
    /// </summary>
    public class UpdateTWAPRequest : Bases.UpdateWapRequest
    {
        public UpdateTWAPRequest()
        {
            Hedge = new();
        }
    }
}
