using System.Text.Json.Serialization;

namespace ATG.API.Types
{
    /// <summary>
    /// Hedge Ratio Type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HedgeLimitRatioType
    {
        /// <summary>
        /// Nenhum
        /// </summary>
        NONE,

        /// <summary>
        /// A dividido por B
        /// </summary>
        A_DIV_B,

        /// <summary>
        /// B dividido por A
        /// </summary>
        B_DIV_A,

        /// <summary>
        /// A menos B
        /// </summary>
        A_LESS_B,

        /// <summary>
        /// B menos A
        /// </summary>
        B_LESS_A
    }

    /// <summary>
    /// Quantity type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HedgeQtyType
    {
        /// <summary>
        /// Fator financeiro
        /// </summary>
        FINANCIAL_FACTOR,

        /// <summary>
        /// Quantidade Fixa
        /// </summary>
        FIXED_QUANTITY
    }

    /// <summary>
    /// Pegged`s placement type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PeggedReferencePriceType
    {
        /// <summary>
        /// Melhor compra
        /// </summary>
        BEST_BUY,

        /// <summary>
        /// Melhor Venda
        /// </summary>
        BEST_SELL,

        /// <summary>
        /// Melhor Ordem
        /// </summary>
        BEST_OFFER
    }

    /// <summary>
    /// Quantity type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuantityType
    {
        /// <summary>
        /// Tipo Quantidade
        /// </summary>
        QUANTITY,

        /// <summary>
        /// Tipo Financeiro
        /// </summary>
        FINANCIAL
    }

    /// <summary>
    /// Indicates Buy or Sell
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Side
    {
        /// <summary>
        /// Compra
        /// </summary>
        BUY,

        /// <summary>
        /// Venda
        /// </summary>
        SELL
    }

    /// <summary>
    /// Simple order type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SimpleOrderType
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

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StrategyStatus
    {
        PENDING_CREATE,
        CREATED,
        RUNNING,
        STOPPED,
        CANCELLED,
        WAITING_TIME,
        REJECT,
        WAITING_STOP,
        CANCELLING,
        FINISHED,
        REJECTED,
        TOTALLY_EXECUTED,
        WAITING_ACK,
        PENDING_CANCEL,
        PENDING_REPLACE,
        OPEN,
        SUSPENDED,
        PARTIALLY_EXECUTED,
        CONFIRMED,
        PENDING_CONFIRMATION,
        PENDING_QUANTITY
    }

    /// <summary>
    /// Validity of sent order
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TimeInForce
    {
        /// <summary>
        /// Válida no dia de envio
        /// </summary>
        DAY,

        /// <summary>
        /// Válida até cancelar
        /// </summary>
        GTC,

        /// <summary>
        /// Valida até a data
        /// </summary>
        GTD,

        /// <summary>
        /// Executa imediatamente no preço e cancela o que sobrar
        /// </summary>
        IOC,

        /// <summary>
        /// Executa tudo ou cancela
        /// </summary>
        FOK,

        /// <summary>
        /// Ordem entrará no Book no leilão de fechamento
        /// </summary>
        MOC,

        /// <summary>
        /// Ordem válida no leilão corrente
        /// </summary>
        MOA
    }

    /// <summary>
    /// Spread Differential Type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpreadBalanceMode
    {
        NONE = -1,

        /// <summary>
        /// Sempre a mercado
        /// </summary>
        MARKET_ALWAYS,

        /// <summary>
        /// Considerar margem
        /// </summary>
        CONSIDER_MARGIN,

        /// <summary>
        /// Preço inicial
        /// </summary>
        INITIAL_PRICE
    }

    /// <summary>
    /// Spread Differential Type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpreadDifferentialType
    {
        /// <summary>
        /// Nenhum
        /// </summary>
        NONE,

        /// <summary>
        /// Quantity
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

    /// <summary>
    /// Spread Loss Compensation
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpreadLossCompensation
    {
        NONE = -1,

        /// <summary>
        /// Nunca
        /// </summary>
        NEVER,

        /// <summary>
        /// Progressiva
        /// </summary>
        PROGRESSIVE,

        /// <summary>
        /// Imediata
        /// </summary>
        IMMEDIATE
    }

    /// <summary>
    /// Behavior in case of Spread slippage
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpreadSlippageMode
    {
        NONE = -1,

        /// <summary>
        /// Manter ordens
        /// </summary>
        KEEP_ORDERS,

        /// <summary>
        /// Ignorar execuções
        /// </summary>
        IGNORE_EXECUTIONS
    }

    /// <summary>
    /// Spread type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
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

    /// <summary>
    /// Validate spread in the money
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpreadValidateInTheMoney
    {
        /// <summary>
        /// Não checar
        /// </summary>
        NO_CHECK,

        /// <summary>
        /// Após o leilão
        /// </summary>
        AFTER_AUCTION,

        /// <summary>
        /// Na criação
        /// </summary>
        ON_CREATION
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StrategyType
    {
        VWAP = 1,
        TWAP = 2,
        POV = 3,
        SPREAD = 4,
        SPREAD3 = 6,
        SPREAD4 = 7,
        DI_SPREAD = 8,
        SIMPLE_ORDER = 10,
        SNIPER = 11,
        TICKET = 13,
        PEGGED = 25,
        ICEBERG = 26,
        FRA_SPREAD = 32,
        FRA_SPREAD3 = 31,
        FRA_SPREAD4 = 30,
        FRA_INCLINATION = 40,
        DI_SPREAD3 = 33,
        DI_SPREAD4 = 34,
        AUCTION_ORDER = 41,
        MARKET_ORDER = 48
    }

    /// <summary>
    /// Auction Order`s type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuctionOrderType
    {
        /// <summary>
        /// Opening Call
        /// </summary>
        OpeningCall,

        /// <summary>
        /// Closing Call
        /// </summary>
        ClosingCall,

        /// <summary>
        /// Intraday Call
        /// </summary>
        IntradayCall
    }

    /// <summary>
    /// Auction Order`s price type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuctionPriceType
    {
        /// <summary>
        /// Always To Market
        /// </summary>
        AlwaysToMarket,

        /// <summary>
        /// Limit Price
        /// </summary>
        LimitPrice,

        /// <summary>
        /// Last Price Variation
        /// </summary>
        LastPriceVariation,
    }
}