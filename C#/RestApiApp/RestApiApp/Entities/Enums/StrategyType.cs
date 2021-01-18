namespace RestApiApp
{
    // Tipos de estratégia para serem recebidos
    public enum StrategyType
    {
        VWAP = 1,
        TWAP = 2,
        POV = 3,
        SPREAD = 4,
        DELTA_HEDGE = 5,
        SPREAD3 = 6,
        SPREAD4 = 7,
        DI_SPREAD = 8,
        SIMPLE_ORDER = 10,
        SNIPER = 11,
        CASH_CARRY = 12,
        TICKET = 13,
        VOL_SKEW = 23,
        PEGGED = 25,
        ICEBERG = 26,
        CROSS_TWAP = 27,
        CROSS_POV = 28,
        CROSS_ORDER = 29,
        FRA_SPREAD = 30,
        FRA_SPREAD3 = 31,
        FRA_SPREAD2 = 32,
        FRA_INCLINATION = 40,
        DI_SPREAD3 = 33,
        DI_SPREAD4 = 34,
        CROSS_SNIPER = 35,
        SCALEIN = 36,
        CROSS_CASH_CARRY = 37,
        SWITCH = 38,
        ADJUSTMENT_CASH_CARRY = 39,
        AUCTION_ORDER = 41,
        CROSS_VWAP = 42,
        CONDITIONAL_ORDER = 43,
        CROSS_SPREAD = 46,
        MARKET_ORDER = 48
    }
}
