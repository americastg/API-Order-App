using Entities;
using Entities.Enums;
using Entities.Spread;
using IdentityModel.Client;
using Newtonsoft.Json;
using RestApiApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Strategies.Spread
{
    static class SpreadExample
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        internal static async Task RunAsync()
        {
            try
            {
                InitHttpClient();
                await InitAuthToken();
                await Task.Delay(1000);

                string strategyId = await NewSpread();
                await Task.Delay(1000);

                string status = await GetSpreadStatusById(strategyId);

                await UpdateSpread(strategyId, status);
                await Task.Delay(1000);

                await CancelSpread(strategyId, status);
                await Task.Delay(1000);

                await GetAllSpreads();
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
        static async Task<string> GetSpreadStatusById(string strategyId)
        {
            var response = await _httpClient.GetAsync("spread");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Consulta do spread: " + response.StatusCode);

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<SpreadReturnedFields>>(listContent);
            var strategySent = deserializedResponse.Find(x => x.StrategyId == strategyId);
            var status = strategySent.Status.ToString();
            Console.WriteLine("Status da estratégia: " + status);
            Console.WriteLine();

            return status;
        }

        // Método para receber informações de todos os envios de spread
        static async Task GetAllSpreads()
        {
            var response = await _httpClient.GetAsync("spread");

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Consulta do spread: " + response.StatusCode);

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonConvert.DeserializeObject<List<SpreadReturnedFields>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonConvert.SerializeObject(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Metodo para criar um spread
        static async Task<string> NewSpread()
        {
            var newSpreadReq = new SpreadRequest
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
            newSpreadReq.AddSpreadInstrument(new SpreadInstrument
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
            newSpreadReq.AddSpreadInstrument(new SpreadInstrument
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

            // Garante que a resposta não contém nenhum erro
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Inclusão do spread: " + response.StatusCode);

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
            LogStrategyResponse(orderResponse, orderResponse.StrategyId);
            CheckOrderResponseError(orderResponse.Error);

            return orderResponse.StrategyId;
        }

        // Método usado pra fazer update do spread
        static async Task UpdateSpread(string strategyId, string status)
        {
            var updateSpreadReq = new SpreadRequest
            {
                SpreadValue = -4.034
            };
            updateSpreadReq.AddSpreadInstrument(new SpreadInstrument
            {
                Quantity = 10000
            });
            updateSpreadReq.AddSpreadInstrument(new SpreadInstrument
            {
                Quantity = 35000
            });

            if (SpreadCanBeUpdated(status))
            {
                var response = await _httpClient.PutAsJsonAsync($"spread/{strategyId}", updateSpreadReq);

                // Garante que a resposta não contém nenhum erro
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Update do spread: " + response.StatusCode);

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Não foi possível realizar um update do spread," +
                    " já que o status atual da estratégia é: " + status);
                Console.WriteLine();
            }
        }

        // Método usado para fazer cancelamento do spread
        static async Task CancelSpread(string strategyId, string status)
        {
            if (SpreadCanBeUpdated(status))
            {
                var response = await _httpClient.DeleteAsync($"spread/{strategyId}");

                // Garante que a resposta não contém nenhum erro
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Cancelamento do spread: " + response.StatusCode);

                var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orderResponse = JsonConvert.DeserializeObject<TradingResponses>(contentResponse);
                LogStrategyResponse(orderResponse, strategyId);
                CheckOrderResponseError(orderResponse.Error);
            }
            else
            {
                Console.WriteLine("Não foi possível realizar um cancelamento do spread," +
                    " já que o status atual da estratégia é: " + status);
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
        static bool SpreadCanBeUpdated(string status)
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