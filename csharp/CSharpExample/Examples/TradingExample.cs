using CSharpExample.Utils;

namespace CSharpExample.Examples
{
    class TradingExample
    {
        private readonly HttpClient _httpClient;

        public TradingExample(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task RunAsync()
        {
            try
            {
                Console.WriteLine("*** RUNNING TRADING EXAMPLE ***");
                Console.WriteLine();

                await GetAllTrades();
                await Task.Delay(500);

                await GetAllStrategies();
                await Task.Delay(500);

                await GetAllStrategiesChangedSinceLastRequest();
                await Task.Delay(500);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Running Example: " + e.Message);
            }
        }

        async Task GetAllTrades(int index = 0)
        {
            Console.WriteLine("*** GETTING ALL TRADES ***");
            var response = await _httpClient.GetAsync($"trading/trades?index={index}");

            await ValidateResponses.ValidateGetTradesResponse(response);
        }

        async Task GetAllStrategies(int page = 0)
        {
            Console.WriteLine("*** GETTING ALL STRATEGIES ***");
            var response = await _httpClient.GetAsync($"trading/strategies?page={page}");

            await ValidateResponses.ValidateGetMultipleStrategiesResponse(response);
        }

        async Task GetAllStrategiesChangedSinceLastRequest()
        {
            Console.WriteLine("*** GETTING ALL STRATEGIES CHANGED SINCE LAST REQUEST ***");
            var response = await _httpClient.GetAsync($"trading/incremental");

            await ValidateResponses.ValidateGetMultipleStrategiesResponse(response);
        }
    }
}