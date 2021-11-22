using Entities;
using Entities.Enums;
using Entities.Simple_Order.Requests;
using Entities.Simple_Order.Responses;
using IdentityModel.Client;
using Newtonsoft.Json;
using RestApiApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Examples.SimpleOrder
{
    static class SimpleOrderExample
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        internal static async Task RunAsync()
        {
            try
            {
                Console.WriteLine("*** RUNNING SIMPLE ORDER EXAMPLE ***");
                Console.WriteLine();

                InitHttpClient();
                await InitAuthToken();
                await Task.Delay(1000);

                string strategyId = await NewSimpleOrder();
                await Task.Delay(2000);

                var simpleOrder = await GetSimpleOrderById(strategyId);
                var status = simpleOrder.Status;
                await Task.Delay(2000);

                await UpdateSimpleOrder(strategyId, status);
                await Task.Delay(2000);

                await CancelSimpleOrder(strategyId, status);
                await Task.Delay(2000);

                await GetAllSimpleOrders();
                await Task.Delay(2000);

                Console.WriteLine();
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

            Console.WriteLine("Got Access Token");
            Console.WriteLine();
        }

        static async Task<SimpleOrderResponse> GetSimpleOrderById(string strategyId)
        {
            Console.WriteLine("*** GETTING SIMPLE ORDER BY ID ***");
            var response = await _httpClient.GetAsync($"simple-order/{strategyId}");
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<SimpleOrderResponse>(listContent);
            Console.WriteLine("SIMPLE ORDER: " + JsonConvert.SerializeObject(deserializedResponse));
            Console.WriteLine();

            return deserializedResponse;
        }

        static async Task GetAllSimpleOrders()
        {
            Console.WriteLine("*** GETTING ALL SIMPLE ORDERS ***");
            var response = await _httpClient.GetAsync("simple-order");
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<SimpleOrderResponse>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonConvert.SerializeObject(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static async Task<string> NewSimpleOrder()
        {
            Console.WriteLine("*** CREATING NEW SIMPLE ORDER ***");
            var response = await _httpClient.PostAsJsonAsync("simple-order",
                new NewSimpleOrderRequest
                {
                    Broker = Config.Broker,
                    Account = Config.Account,
                    OrderType = OrderType.LIMIT,
                    Symbol = "SULA11",
                    Side = Side.BUY,
                    Quantity = 300,
                    Price = 5.45,
                    TimeInForce = TimeInForce.DAY
                });
            response.EnsureSuccessStatusCode();

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<StrategyResponse>(contentResponse);
            LogStrategyResponse(orderResponse, orderResponse.StrategyId);
            CheckOrderResponseError(orderResponse.Error);

            return orderResponse.StrategyId;
        }

        static async Task UpdateSimpleOrder(string strategyId, Status status)
        {
            Console.WriteLine("*** UPDATING SIMPLE ORDER ***");
            if (SimpleOrderCanBeUpdated(status))
            {
                var response = await _httpClient.PutAsJsonAsync($"simple-order/{strategyId}",
                new UpdateSimpleOrderRequest { Quantity = 50000 });

                response.EnsureSuccessStatusCode();

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<StrategyResponse>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Simple order update cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        static async Task CancelSimpleOrder(string strategyId, Status status)
        {
            Console.WriteLine("*** CANCELLING SIMPLE ORDER ***");
            if (SimpleOrderCanBeUpdated(status))
            {
                var response = await _httpClient.DeleteAsync($"simple-order/{strategyId}");
                response.EnsureSuccessStatusCode();

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<StrategyResponse>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Simple order cancel cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        static void LogStrategyResponse(StrategyResponse orderResponse, string strategyId)
        {
            Console.WriteLine("Response messageID: " + orderResponse.MessageId);
            Console.WriteLine("Response strategyID: " + strategyId);
            Console.WriteLine("Response success: " + orderResponse.Success);
            Console.WriteLine("Response error: " + orderResponse.Error);
            Console.WriteLine();
        }

        static void CheckOrderResponseError(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Response error:");
                Console.WriteLine();

                throw new Exception(error);
            }
        }

        static bool SimpleOrderCanBeUpdated(Status status)
        {
            if (status == Status.CANCELLED ||
                status == Status.FINISHED ||
                status == Status.TOTALLY_EXECUTED)
                return false;

            return true;
        }
    }
}