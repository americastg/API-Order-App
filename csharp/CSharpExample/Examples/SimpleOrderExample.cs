using ATG.API.Types;
using ATG.API.Types.Requests;
using ATG.API.Types.Strategies;
using System.Text.Json;
using System.Net.Http.Json;
using CSharpExample.Utils;

namespace CSharpExample.Examples
{
    class SimpleOrderExample
    {
        private readonly HttpClient _httpClient;
        private readonly Config _config;

        public SimpleOrderExample(HttpClient client, Config config)
        {
            _httpClient = client;
            _config = config;
        }

        public async Task RunAsync()
        {
            try
            {
                Console.WriteLine("*** RUNNING SIMPLE ORDER EXAMPLE ***");
                Console.WriteLine();

                string strategyId = await NewSimpleOrder();
                await Task.Delay(1000);

                var simpleOrder = await GetSimpleOrderById(strategyId);
                var status = simpleOrder.Status;
                await Task.Delay(500);

                await UpdateSimpleOrder(strategyId, status);
                await Task.Delay(500);

                await CancelSimpleOrder(strategyId, status);
                await Task.Delay(500);

                await GetAllSimpleOrders();
                await Task.Delay(500);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Running Example: " + e.Message);
            }
        }

        async Task<SimpleOrder> GetSimpleOrderById(string strategyId)
        {
            Console.WriteLine("*** GETTING SIMPLE ORDER BY ID ***");
            var response = await _httpClient.GetAsync($"simple-order/{strategyId}");
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonSerializer.Deserialize<SimpleOrder>(listContent);
            Console.WriteLine("SIMPLE ORDER: " + JsonSerializer.Serialize(deserializedResponse));
            Console.WriteLine();

            return deserializedResponse;
        }

        async Task GetAllSimpleOrders(int page = 0)
        {
            Console.WriteLine("*** GETTING ALL SIMPLE ORDERS ***");
            var response = await _httpClient.GetAsync($"simple-order?page={page}");

            await ValidateResponses.ValidateGetResponse<SimpleOrder>(response);
        }

        async Task<string> NewSimpleOrder()
        {
            Console.WriteLine("*** CREATING NEW SIMPLE ORDER ***");
            var response = await _httpClient.PostAsJsonAsync("simple-order",
                new NewSimpleOrderRequest
                {
                    Broker = _config.Broker,
                    Account = _config.Account,
                    OrderType = SimpleOrderType.LIMIT,
                    Symbol = "SULA11",
                    Side = Side.BUY,
                    Quantity = 300,
                    Price = 15.45,
                    TimeInForce = TimeInForce.DAY
                });

            return await ValidateResponses.ValidateNewResponse(response);
        }

        async Task UpdateSimpleOrder(string strategyId, StrategyStatus status)
        {
            Console.WriteLine("*** UPDATING SIMPLE ORDER ***");
            if (SimpleOrderCanBeUpdated(status))
            {
                var response = await _httpClient.PutAsJsonAsync($"simple-order/{strategyId}",
                new UpdateSimpleOrderRequest { Quantity = 50000 });

                await ValidateResponses.ValidateUpdateCancelResponse(response);
            }
            else
            {
                Console.WriteLine("Simple order update cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        async Task CancelSimpleOrder(string strategyId, StrategyStatus status)
        {
            Console.WriteLine("*** CANCELLING SIMPLE ORDER ***");
            if (SimpleOrderCanBeUpdated(status))
            {
                var response = await _httpClient.DeleteAsync($"simple-order/{strategyId}");

                await ValidateResponses.ValidateUpdateCancelResponse(response);
            }
            else
            {
                Console.WriteLine("Simple order cancel cannot be done, since the current status is: " + status);
                Console.WriteLine();
            }
        }

        bool SimpleOrderCanBeUpdated(StrategyStatus status)
        {
            if (status == StrategyStatus.CANCELLED ||
                status == StrategyStatus.FINISHED ||
                status == StrategyStatus.TOTALLY_EXECUTED)
                return false;

            return true;
        }
    }
}