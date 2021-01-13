using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestApiApp
{
    internal static class Config
    {
        internal static readonly string BaseAddress = ConfigurationManager.AppSettings[nameof(BaseAddress)];
        internal static readonly string TokenAddress = ConfigurationManager.AppSettings[nameof(TokenAddress)];
        internal static readonly string ClientID = ConfigurationManager.AppSettings[nameof(ClientID)];
        internal static readonly string ClientSecret = ConfigurationManager.AppSettings[nameof(ClientSecret)];
        internal static readonly string Scope = ConfigurationManager.AppSettings[nameof(Scope)];
        internal static readonly string Username = ConfigurationManager.AppSettings[nameof(Username)];
        internal static readonly string Password = ConfigurationManager.AppSettings[nameof(Password)];
        internal static readonly string Broker = ConfigurationManager.AppSettings[nameof(Broker)];
        internal static readonly string Account = ConfigurationManager.AppSettings[nameof(Account)];
    }

    class Program
    {
        public static TradingResponses Response;
        private static readonly HttpClient _httpClient = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        public static async Task RunAsync()
        {
            await GetToken();
            await Task.Delay(1000);

            await NewSimpleOrder();
            await Task.Delay(1000);

            await UpdateSimpleOrder();
            await Task.Delay(1000);

            await CancelSimpleOrder();
            await Task.Delay(1000);

            await GetSimpleOrder();
            await Task.Delay(1000);
        }

        // Irá pegar o token necessário para envio de ordens pela API
        static async Task GetToken()
        {
            _httpClient.BaseAddress = new Uri(Config.BaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = Config.TokenAddress,
                ClientId = Config.ClientID,
                ClientSecret = Config.ClientSecret,
                Scope = Config.Scope,
                UserName = Config.Username,
                Password = Config.Password
            });

            if (response.IsError) throw new Exception(response.Error);

            var token = response.AccessToken.ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            Console.WriteLine("Token de acesso conseguido");
            Console.WriteLine();
        }

        // Metodo para criar uma ordem simples a partir dos parâmetros colocados no método anterior
        static async Task NewSimpleOrder()
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("simple-order", new SimpleOrder
            {
                Broker = Config.Broker,
                Account = Config.Account,
                OrderType = OrderType.LIMIT,
                Symbol = "PETR4",
                Side = Side.SELL,
                Quantity = 300,
                Price = 19.00,
                DisplayQuantity = 200,
                TimeInForce = TimeInForce.DAY,
                ExpireDate = DateTime.Now.AddDays(1)
            });

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Inclusão de ordem simples com status: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Response = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            Console.WriteLine("Response messageID: " + Response.MessageId);
            Console.WriteLine("Response strategyID: " + Response.StrategyId);
            Console.WriteLine("Response success: " + Response.Success);
            Console.WriteLine("Response error: " + Response.Error);
            Console.WriteLine();
        }

        // Método para receber informações de todos os envios de ordem simples
        static async Task GetSimpleOrder()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("simple-order");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Consulta de ordem simples com status: " + response.StatusCode);

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<StrategyResponseSamples>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonConvert.SerializeObject(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Método usado pra fazer update de ordem simples
        static async Task UpdateSimpleOrder()
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"simple-order/{Response.StrategyId}", new SimpleOrder
            {
                Quantity = 50000
            });

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Update de ordem simples com status: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Response = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            Console.WriteLine("Response messageID: " + Response.MessageId);
            Console.WriteLine("Response strategyID: " + Response.StrategyId);
            Console.WriteLine("Response success: " + Response.Success);
            Console.WriteLine("Response error: " + Response.Error);
            Console.WriteLine();
        }

        // Método usado para fazer cancelamento de ordem simples
        static async Task CancelSimpleOrder()
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"simple-order/{Response.StrategyId}");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Cancelamento de ordem simples com status: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Response = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            Console.WriteLine("Response messageID: " + Response.MessageId);
            Console.WriteLine("Response strategyID: " + Response.StrategyId);
            Console.WriteLine("Response success: " + Response.Success);
            Console.WriteLine("Response error: " + Response.Error);
            Console.WriteLine();
        }
    }

    // Classe com todos os parâmetros necessários para criação de ordem simples
    // olhar documentação para verificar quais campos são obrigatórios na hora do envio da estratégia
    public class SimpleOrder
    {
        public string Broker { get; set; }
        public string Account { get; set; }
        public OrderType OrderType { get; set; }
        public string Symbol { get; set; }
        public Side Side { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double StopTriggerPrice { get; set; }
        public long DisplayQuantity { get; set; }
        public long MinQuantity { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime ExpireDate { get; set; }
        public string StartTime { get; set; }
    }

    // Respostas do envio da ordem pela API
    public class TradingResponses
    {
        public long MessageId { get; set; }
        public string StrategyId { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
    }

    // Respostas para conferir que a ordem enviada confere com a resposta da API
    public class StrategyResponseSamples
    {
        public StrategyType StrategyType { get; set; }
        public string Account { get; set; }
        public string Broker { get; set; }
        public long ExecutedQuantity { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ExpireDate { get; set; }
        public OrderType OrderType { get; set; }
        public double Price { get; set; }
        public double AvgPrice { get; set; }
        public long Quantity { get; set; }
        public long DisplayQuantity { get; set; }
        public long MinQuantity { get; set; }
        public Side Side { get; set; }
        public Status Status { get; set; }
        public string Symbol { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public string StrategyId { get; set; }
    }

    // Tipos de estratégia para serem recebidos
    public enum StrategyType
    {
        INVALID, NONE, ALWAYS, VWAP, TWAP, POV, SPREAD, DELTA_HEDGE, SPREAD3,
        SPREAD4, DI_SPREAD, SIMPLE_ORDER, SNIPER, CASH_CARRY, VOL_SKEW, PEGGED,
        ICEBERG, CROSS_TWAP, CROSS_POV, CROSS_ORDER, FRA_SPREAD, FRA_SPREAD3,
        FRA_SPREAD2, FRA_INCLINATION, DI_SPREAD3, DI_SPREAD4, CROSS_SNIPER,
        SCALEIN, CROSS_CASH_CARRY, SWITCH, ADJUSTMENT_CASH_CARRY, AUCTION_ORDER,
        CROSS_VWAP, CONDITIONAL_ORDER, FINDER, BARCELONA, CROSS_SPREAD, CROSS_FX,
        MARKET_ORDER, DMA, WORKED, WORKED_RESERVE_ORDER, WORKED_REPORT_ORDER,
        TRADE_BUST, PL_REPORT_ORDER, TICKET, TICKET_CHILDREN, ITAU_ICEBERG,
        ORDER_PER_MINUTE, STRATEGY_SUMMARY, PL, OPENED_ORDERS, BASKET, STRATEGY_COMBO,
        TRADES, FATFINGER, STRATEGY_CONSOLIDATED, SUMMARY_GROUP, MARKET_WATCH, BOOK,
        TS, CHART, MARKET_NEWS, BROKER_RANKING, FAST_TRADE, OPTION_WATCH, BTC_TOOL,
        CASH_CARRY_MARKET_VIEWER, ALERTS, TRADES_REPORT, EXECUTION_REPORT, MULTILEVEL
    }

    // Tipos de status para serem recebidos
    public enum Status
    {
        PENDING_CREATE, CREATED, RUNNING, STOPPED, CANCELLED, WAITING_TIME, REJECT, WAITING_STOP,
        CANCELLING, FINISHED, REJECTED, TOTALLY_EXECUTED, WAITING_ACK, PENDING_CANCEL, PENDING_REPLACE,
        OPEN, SUSPENDED, PARTIALLY_EXECUTED
    }

    // Tipos de ordem
    public enum OrderType
    {
        LIMIT,
        MARKET_LIMIT,
        MARKET,
        STOP_LIMIT,
        STOP_MARKET
    }

    // Tipos de lado
    public enum Side
    {
        BUY,
        SELL
    }

    // Tipos de validade
    public enum TimeInForce
    {
        DAY,
        GTC,
        GTD,
        IOC,
        FOK,
        MOC,
        MOA
    }
}