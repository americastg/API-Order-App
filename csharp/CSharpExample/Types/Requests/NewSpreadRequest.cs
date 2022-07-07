using ATG.API.Types.Strategies;

namespace ATG.API.Types.Requests
{
    /// <summary>
    /// Requisição de Spread
    /// </summary>
    public class NewSpreadRequest : Bases.NewArbitragesRequest
    {
        /// <summary>
        /// Information about each Spread instrument
        /// </summary>
        public new List<SpreadInstrument> Instruments { get; set; }

        /// <summary>
        /// Spread Type. Division spreads are only available if it's a 2 legged spread
        /// </summary>
        public SpreadType SpreadType { get; set; }

        /// <summary>
        /// Tipo de diferencial<br />
        /// O valor <code>NONE</code> é um atalho para o valor <code>VALUE</code> com PriceFator 1 em cada perna<br />
        /// Ao usar <code>VALUE</code>, pode-se usar o PriceFactor em cada perna
        /// </summary>
        public SpreadDifferentialType DifferentialType { get; set; }

        /// <summary>
        /// Tipo de diferencial<br />
        /// Disponível apenas em Spreads de duas pontas
        /// </summary>
        public QuantityType QuantityType { get; set; }

        /// <summary>
        /// Matched Financial<br />
        /// When used, the QuantityType, LossCompensation and Quantity of the second leg will be ignored<br />
        /// Only available in Double-leg Spreads
        /// </summary>
        public bool IsMatchedFinancial { get; set; } = false;

        public NewSpreadRequest()
        {
            Instruments = new();
        }
    }
}