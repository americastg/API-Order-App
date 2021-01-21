namespace Entities.Enums
{
    public enum SpreadType
    {
        /// <summary>
        /// Preço de Compra / Preço de Venda. Disponível apenas para Spread com 2 instrumentos
        /// </summary>
        BUY_DIV_SELL,

        /// <summary>
        /// Preço de Venda / Preço de Compra. Disponível apenas para Spread com 2 instrumentos
        /// </summary>
        SELL_DIV_BUY,

        /// <summary>
        /// Preço de Compra - Preço de Venda
        /// </summary>
        BUY_MINUS_SELL,

        /// <summary>
        /// Preço de Venda - Preço de Compra
        /// O fator é opcional
        /// </summary>
        SELL_MINUS_BUY,

        /// <summary>
        /// Fator do Instrumento de Compra * Preço de Compra + Preço de Venda * Fator do Instrumento de Venda
        /// Ao utilizar este tipo de Spread, o parâmetro <i>Factor</i> do Instrumento passa a ser obrigatório.
        /// </summary>
        FACTOR,

        /// <summary>
        /// Financeiro gerado de Compra + Financeiro gerado de Venda
        /// </summary>
        FINANCIAL
    }
}