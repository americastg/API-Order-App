namespace RestApiApp
{
    // Tipos de ordem
    public enum OrderType
    {
        /// <summary>
        /// Ordem limitada
        /// </summary>
        LIMIT,

        /// <summary>
        /// Mercado Limitado
        /// </summary>
        MARKET_LIMIT,

        /// <summary>
        /// Mercado Protegido
        /// </summary>
        MARKET,

        /// <summary>
        /// Ordem do tipo Stop com preço limite
        /// </summary>
        STOP_LIMIT,

        /// <summary>
        /// Ordem do tipo Stop a mercado
        /// </summary>
        STOP_MARKET
    }
}