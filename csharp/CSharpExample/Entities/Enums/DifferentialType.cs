namespace Entities.Enums
{
    public enum DifferentialType
    {
        /// <summary>
        /// Nenhum
        /// </summary>
        NONE,

        /// <summary>
        /// Quantidade
        /// </summary>
        QUANTITY,

        /// <summary>
        /// Valor
        /// </summary>
        /// <remarks>
        /// Ao usar este tipo de diferencial, passa a ser opcional o uso do <i>Fator</i> nos instrumentos, caso o tipo do Spread seja Compra - Venda ou Venda - Compra
        /// </remarks>
        VALUE
    }
}