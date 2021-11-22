using Entities;
using Entities.Enums;
using Entities.Spread.Requests;
using Entities.Spread.Responses;
using IdentityModel.Client;
using Newtonsoft.Json;
using RestApiApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Examples.Spread
{
    static class SpreadExample
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        internal static async Task RunAsync()
        {
            try
            {
                Console.WriteLine("*** RUNNING SPREAD EXAMPLE ***");
                Console.WriteLine();

                InitHttpClient();
                await InitAuthToken();
                await Task.Delay(1000);

                string strategyId = await NewSpread();
                await Task.Delay(2000);

                var spreadOrder = await GetSpreadById(strategyId);
                var status = spreadOrder.Status;
                await Task.Delay(2000);

                await UpdateSpread(strategyId, status);
                await Task.Delay(2000);

                await CancelSpread(strategyId, status);
                await Task.Delay(2000);

                await GetAllSpreads();
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

        static async Task<SpreadResponse> GetSpreadById(string strategyId)
        {
            Console.WriteLine("*** GETTING SPREAD BY ID ***");
            var response = await _httpClient.GetAsync($"spread/{strategyId}");
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<SpreadResponse>(listContent);
            Console.WriteLine("SPREAD ORDER: " + JsonConvert.SerializeObject(deserializedResponse));
            Console.WriteLine();

            return deserializedResponse;
        }

        static async Task GetAllSpreads()
        {
            Console.WriteLine("*** GETTING ALL SPREADS ***");
            var response = await _httpClient.GetAsync("spread");
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<SpreadResponse>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonConvert.SerializeObject(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static async Task<string> NewSpread()
        {
            Console.WriteLine("*** CREATING NEW SPREAD ***");
            var newSpreadReq = new NewSpreadRequest
            {
                Broker = Config.Broker,
                Account = Config.Account,
                SpreadValue = 1.0,
                SpreadType = SpreadType.BUY_MINUS_SELL,
                DifferentialType = DifferentialType.NONE,
                QuantityType = QuantityType.QUANTITY,
                StartTime = "10:00",
                EndTime = "21:00",
                SlippageMode = SlippageMode.KEEP_ORDERS,
                BalanceMode = BalanceMode.MARKET_ALWAYS,
                IsMatchedFinancial = true,
                LossCompensation = LossCompensation.NEVER,
                ValidateSpreadInTheMoney = ValidateSpreadInTheMoney.NO_CHECK,
                MaxSlippageQuantity = 3000,
                ReverseSpreadValue = 0.4,
                SpreadMargin = 0.01,
                StopTime = "20:00",
                WaitTime = 0,
                ShouldCreateReverseSpreadOnFinish = false
            };
            newSpreadReq.AddSpreadInstrument(new NewSpreadInstrument
            {
                Symbol = "SULA11",
                Side = Side.BUY,
                Quantity = 40000,
                MaxDisplayQuantity = 10000,
                SimultaneousOrders = 2,
                PriceFactor = 0,
                Depth = -1,
                Placement = true,
                AllowExecution = true,
                PlaceOverBestOffer = true
            });
            newSpreadReq.AddSpreadInstrument(new NewSpreadInstrument
            {
                Symbol = "SULA4",
                Side = Side.SELL,
                Quantity = 45000,
                MaxDisplayQuantity = 13000,
                SimultaneousOrders = 4,
                PriceFactor = 1,
                Depth = -1,
                Placement = true,
                AllowExecution = true,
                PlaceOverBestOffer = true
            });

            var response = await _httpClient.PostAsJsonAsync("spread", newSpreadReq);
            response.EnsureSuccessStatusCode();

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<StrategyResponse>(contentResponse);
            LogStrategyResponse(orderResponse, orderResponse.StrategyId);
            CheckOrderResponseError(orderResponse.Error);

            return orderResponse.StrategyId;
        }

        static async Task UpdateSpread(string strategyId, Status status)
        {
            Console.WriteLine("*** UPDATING SPREAD ***");
            var updateSpreadReq = new UpdateSpreadRequest
            {
                SpreadValue = -4.034
            };
            updateSpreadReq.AddSpreadInstrument(new UpdateSpreadInstrument
            {
                Quantity = 10000
            });
            updateSpreadReq.AddSpreadInstrument(new UpdateSpreadInstrument
            {
                Quantity = 35000
            });

            if (SpreadCanBeUpdated(status))
            {
                var response = await _httpClient.PutAsJsonAsync($"spread/{strategyId}", updateSpreadReq);
                response.EnsureSuccessStatusCode();

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<StrategyResponse>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Spread update cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        static async Task CancelSpread(string strategyId, Status status)
        {
            Console.WriteLine("*** CANCELLING SPREAD ***");
            if (SpreadCanBeUpdated(status))
            {
                var response = await _httpClient.DeleteAsync($"spread/{strategyId}");
                response.EnsureSuccessStatusCode();

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<StrategyResponse>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Spread cancel cannot be done, since the current status is: " + status);
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

        static bool SpreadCanBeUpdated(Status status)
        {
            if (status == Status.CANCELLED ||
                status == Status.FINISHED ||
                status == Status.TOTALLY_EXECUTED)
                return false;

            return true;
        }
    }
}