namespace RestApiApp
{
    // Tipos de validade
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
}