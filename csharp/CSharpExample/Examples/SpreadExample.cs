using ATG.API.Types;
using ATG.API.Types.Requests;
using ATG.API.Types.Strategies;
using System.Text.Json;
using System.Net.Http.Json;
using CSharpExample.Utils;

namespace CSharpExample.Examples
{
    class SpreadExample
    {
        private readonly HttpClient _httpClient;
        private readonly Config _config;

        public SpreadExample(HttpClient client, Config config)
        {
            _httpClient = client;
            _config = config;
        }

        public async Task RunAsync()
        {
            try
            {
                Console.WriteLine("*** RUNNING SPREAD EXAMPLE ***");
                Console.WriteLine();

                string strategyId = await NewSpread();
                await Task.Delay(1000);

                var spreadOrder = await GetSpreadById(strategyId);
                var status = spreadOrder.Status;
                await Task.Delay(500);

                await UpdateSpread(strategyId, status);
                await Task.Delay(500);

                await CancelSpread(strategyId, status);
                await Task.Delay(500);

                await GetAllSpreads();
                await Task.Delay(500);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Running Example: " + e.Message);
            }
        }

        async Task<Spread> GetSpreadById(string strategyId)
        {
            Console.WriteLine("*** GETTING SPREAD BY ID ***");
            var response = await _httpClient.GetAsync($"spread/{strategyId}");
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonSerializer.Deserialize<Spread>(listContent);
            Console.WriteLine("SPREAD ORDER: " + JsonSerializer.Serialize(deserializedResponse));
            Console.WriteLine();

            return deserializedResponse;
        }

        async Task GetAllSpreads(int page = 0)
        {
            Console.WriteLine("*** GETTING ALL SPREADS ***");
            var response = await _httpClient.GetAsync($"spread?page={page}");
            
            await ValidateResponses.ValidateGetResponse<SimpleOrder>(response);
        }

        async Task<string> NewSpread()
        {
            Console.WriteLine("*** CREATING NEW SPREAD ***");
            var newSpreadReq = new NewSpreadRequest
            {
                Broker = _config.Broker,
                Account = _config.Account,
                SpreadValue = 1.0,
                SpreadType = SpreadType.BUY_MINUS_SELL,
                DifferentialType = SpreadDifferentialType.NONE,
                QuantityType = QuantityType.QUANTITY,
                StartTime = "10:00",
                EndTime = "21:00",
                SlippageMode = SpreadSlippageMode.KEEP_ORDERS,
                BalanceMode = SpreadBalanceMode.MARKET_ALWAYS,
                IsMatchedFinancial = true,
                LossCompensation = SpreadLossCompensation.NEVER,
                ValidateSpreadInTheMoney = SpreadValidateInTheMoney.NO_CHECK,
                MaxSlippageQuantity = 3000,
                ReverseSpreadValue = 0.4,
                SpreadMargin = 0.01,
                StopTime = "20:00",
                WaitTime = 0,
                ShouldCreateReverseSpreadOnFinish = false
            };
            newSpreadReq.Instruments.Add(new SpreadInstrument
            {
                Symbol = "SULA11",
                Side = Side.BUY,
                Quantity = 4000,
                MaxDisplayQuantity = 1000,
                SimultaneousOrders = 2,
                PriceFactor = 0,
                Depth = -1,
                Placement = true,
                AllowExecution = true,
                PlaceOverBestOffer = true
            });
            newSpreadReq.Instruments.Add(new SpreadInstrument
            {
                Symbol = "SULA4",
                Side = Side.SELL,
                Quantity = 4500,
                MaxDisplayQuantity = 1300,
                SimultaneousOrders = 4,
                PriceFactor = 1,
                Depth = -1,
                Placement = true,
                AllowExecution = true,
                PlaceOverBestOffer = true
            });

            var response = await _httpClient.PostAsJsonAsync("spread", newSpreadReq);

            return await ValidateResponses.ValidateNewResponse(response);
        }

        async Task UpdateSpread(string strategyId, StrategyStatus status)
        {
            Console.WriteLine("*** UPDATING SPREAD ***");
            var updateSpreadReq = new UpdateSpreadRequest
            {
                SpreadValue = -4.034
            };
            updateSpreadReq.Instruments.Add(new UpdateSpreadInstrument
            {
                Quantity = 1000
            });
            updateSpreadReq.Instruments.Add(new UpdateSpreadInstrument
            {
                Quantity = 3500
            });

            if (SpreadCanBeUpdated(status))
            {
                var response = await _httpClient.PutAsJsonAsync($"spread/{strategyId}", updateSpreadReq);
                
                await ValidateResponses.ValidateUpdateCancelResponse(response);
            }
            else
            {
                Console.WriteLine("Spread update cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        async Task CancelSpread(string strategyId, StrategyStatus status)
        {
            Console.WriteLine("*** CANCELLING SPREAD ***");
            if (SpreadCanBeUpdated(status))
            {
                var response = await _httpClient.DeleteAsync($"spread/{strategyId}");

                await ValidateResponses.ValidateUpdateCancelResponse(response);
            }
            else
            {
                Console.WriteLine("Spread cancel cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        bool SpreadCanBeUpdated(StrategyStatus status)
        {
            if (status == StrategyStatus.CANCELLED ||
                status == StrategyStatus.FINISHED ||
                status == StrategyStatus.TOTALLY_EXECUTED)
                return false;

            return true;
        }
    }
}