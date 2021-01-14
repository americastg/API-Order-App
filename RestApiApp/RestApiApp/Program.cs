using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestApiApp
{
    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        async static Task Main(string[] args)
        {
            await RunAsync();
            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            await GetToken();
            await Task.Delay(1000);

            string strategyId = await NewSimpleOrder();
            await Task.Delay(1000);

            await UpdateSimpleOrder(strategyId);
            await Task.Delay(1000);

            await CancelSimpleOrder(strategyId);
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

        // Metodo para criar uma ordem simples a partir dos parâmetros colocados no método anterior
        static async Task<string> NewSimpleOrder()
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("simple-order",
                new SimpleOrder
                {
                    Broker = Config.Broker,
                    Account = Config.Account,
                    OrderType = OrderType.LIMIT,
                    Symbol = "SULA4",
                    Side = Side.SELL,
                    Quantity = 300,
                    Price = 19.00,
                    DisplayQuantity = 200,
                    TimeInForce = TimeInForce.DAY
                });

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Inclusão de ordem simples com status: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            Console.WriteLine("Response messageID: " + orderResponse.MessageId);
            Console.WriteLine("Response strategyID: " + orderResponse.StrategyId);
            Console.WriteLine("Response success: " + orderResponse.Success);
            Console.WriteLine("Response error: " + orderResponse.Error);
            Console.WriteLine();

            return orderResponse.StrategyId;
        }

        // Método usado pra fazer update de ordem simples
        static async Task UpdateSimpleOrder(string strategyId)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"simple-order/{strategyId}",
                new SimpleOrder { Quantity = 50000 });

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Update de ordem simples com status: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            Console.WriteLine("Response messageID: " + orderResponse.MessageId);
            Console.WriteLine("Response strategyID: " + strategyId);
            Console.WriteLine("Response success: " + orderResponse.Success);
            Console.WriteLine("Response error: " + orderResponse.Error);
            Console.WriteLine();
        }

        // Método usado para fazer cancelamento de ordem simples
        static async Task CancelSimpleOrder(string strategyId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"simple-order/{strategyId}");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Cancelamento de ordem simples com status: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            Console.WriteLine("Response messageID: " + orderResponse.MessageId);
            Console.WriteLine("Response strategyID: " + strategyId);
            Console.WriteLine("Response success: " + orderResponse.Success);
            Console.WriteLine("Response error: " + orderResponse.Error);
            Console.WriteLine();
        }
    }
}