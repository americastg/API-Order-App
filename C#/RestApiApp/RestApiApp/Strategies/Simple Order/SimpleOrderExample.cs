using Entities;
using Entities.Enums;
using Entities.SimpleOrder;
using IdentityModel.Client;
using Newtonsoft.Json;
using RestApiApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Strategies.SimpleOrder
{
    static class SimpleOrderExample
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        internal static async Task RunAsync()
        {
            try
            {
                InitHttpClient();
                await InitAuthToken();
                await Task.Delay(1000);

                string strategyId = await NewSimpleOrder();
                await Task.Delay(1000);

                string status = await GetSimpleOrderStatusById(strategyId);

                await UpdateSimpleOrder(strategyId, status);
                await Task.Delay(1000);

                await CancelSimpleOrder(strategyId, status);
                await Task.Delay(1000);

                await GetAllSimpleOrders();
                await Task.Delay(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void InitHttpClient()
        {
            _httpClient.BaseAddress = new Uri(Config.BaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Irá pegar o token necessário para envio de ordens pela API
        static async Task InitAuthToken()
        {
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

            Console.WriteLine("Token de acesso obtido");
            Console.WriteLine();
        }

        // Método para pegar o status, através do strategyId da ordem
        static async Task<string> GetSimpleOrderStatusById(string strategyId)
        {
            var response = await _httpClient.GetAsync("simple-order");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Consulta de ordem simples: " + response.StatusCode);

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<SimpleOrderReturnedFields>>(listContent);
            var strategySent = deserializedResponse.Find(x => x.StrategyId == strategyId);
            var status = strategySent.Status.ToString();
            Console.WriteLine("Status da ordem: " + status);
            Console.WriteLine();

            return status;
        }

        // Método para receber informações de todos os envios de ordem simples
        static async Task GetAllSimpleOrders()
        {
            var response = await _httpClient.GetAsync("simple-order");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Consulta de ordem simples: " + response.StatusCode);

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<SimpleOrderReturnedFields>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonConvert.SerializeObject(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Metodo para criar uma ordem simples
        static async Task<string> NewSimpleOrder()
        {
            var response = await _httpClient.PostAsJsonAsync("simple-order",
                new SimpleOrderRequest
                {
                    Broker = Config.Broker,
                    Account = Config.Account,
                    OrderType = OrderType.LIMIT,
                    Symbol = "SULA4", // papel 'exótico' para garantir que a ordem não irá executar antes do update
                    Side = Side.SELL,
                    Quantity = 300,
                    Price = 19.00,
                    DisplayQuantity = 200,
                    TimeInForce = TimeInForce.DAY
                });

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Inclusão de ordem simples: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            LogStrategyResponse(orderResponse, orderResponse.StrategyId);
            CheckOrderResponseError(orderResponse.Error);

            return orderResponse.StrategyId;
        }

        // Método usado pra fazer update de ordem simples
        static async Task UpdateSimpleOrder(string strategyId, string status)
        {
            if (SimpleOrderCanBeUpdated(status))
            {
                var response = await _httpClient.PutAsJsonAsync($"simple-order/{strategyId}",
                new SimpleOrderRequest { Quantity = 50000 });

                // Garante que a resposta não contém nenhum erro
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Update de ordem simples: " + response.StatusCode);

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Não foi possível realizar um update da ordem simples," +
                    " já que o status atual da ordem é: " + status);
                Console.WriteLine();
            }
        }

        // Método usado para fazer cancelamento de ordem simples
        static async Task CancelSimpleOrder(string strategyId, string status)
        {
            if (SimpleOrderCanBeUpdated(status))
            {
                var response = await _httpClient.DeleteAsync($"simple-order/{strategyId}");

                // Garante que a resposta não contém nenhum erro
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Cancelamento de ordem simples: " + response.StatusCode);

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Não foi possível realizar um cancelamento da ordem simples," +
                    " já que o status atual da ordem é: " + status);
                Console.WriteLine();
            }
        }

        // Método usado para logar a resposta da API após qualquer request enviado
        static void LogStrategyResponse(TradingResponses orderResponse, string strategyId)
        {
            Console.WriteLine("Response messageID: " + orderResponse.MessageId);
            Console.WriteLine("Response strategyID: " + strategyId);
            Console.WriteLine("Response success: " + orderResponse.Success);
            Console.WriteLine("Response error: " + orderResponse.Error);
            Console.WriteLine();
        }

        // Método se há algum erro no retorno do envio da ordem
        static void CheckOrderResponseError(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Erro no retorno da API:");
                throw new Exception(error);
            }
        }

        // Método que verifica se a estratégia pode ser modificada, através do status
        static bool SimpleOrderCanBeUpdated(string status)
        {
            Status statusEnum = (Status)Enum.Parse(typeof(Status), status);
            if (statusEnum == Status.CANCELLED ||
                statusEnum == Status.FINISHED ||
                statusEnum == Status.TOTALLY_EXECUTED)
                return false;

            return true;
        }
    }
}