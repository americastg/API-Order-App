using ATG.API.Types;
using ATG.API.Types.Strategies;
using System.Text.Json;

namespace CSharpExample.Utils
{
    public static class ValidateResponses
    {
        public static async Task ValidateGetResponse<T>(HttpResponseMessage response)
            where T : BaseStrategy
        {
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonSerializer.Deserialize<List<T>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonSerializer.Serialize(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static async Task ValidateGetMultipleStrategiesResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonSerializer.Deserialize<List<JsonElement>>(listContent);

            var strategyResponseDict = StrategyMapper(deserializedResponse);

            foreach (var obj in strategyResponseDict)
            {
                Console.WriteLine(obj.Key);
                foreach (var item in obj.Value)
                    Console.WriteLine(JsonSerializer.Serialize(item));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void ValidateWebSocketMessageResponse(string snapshot)
        {
            var (type, strategy) = StrategyMapper(snapshot);

            Console.WriteLine($"{type}: {JsonSerializer.Serialize(strategy)}");
            Console.WriteLine();
        }

        public static async Task ValidateGetTradesResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var listContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedResponse = JsonSerializer.Deserialize<List<Trade>>(listContent);
            foreach (var obj in deserializedResponse)
            {
                var serializedObj = JsonSerializer.Serialize(obj);
                Console.WriteLine(serializedObj);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static async Task ValidateUpdateCancelResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonSerializer.Deserialize<StrategyResponse>(contentResponse);
            LogStrategyResponse(orderResponse);
            CheckOrderResponseError(orderResponse.Error);
        }

        public static async Task<string> ValidateNewResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var contentResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var orderResponse = JsonSerializer.Deserialize<StrategyResponse>(contentResponse);
            LogStrategyResponse(orderResponse);
            CheckOrderResponseError(orderResponse.Error);

            return orderResponse.StrategyId;
        }

        private static void LogStrategyResponse(StrategyResponse orderResponse)
        {
            Console.WriteLine(JsonSerializer.Serialize(orderResponse));
            Console.WriteLine();
        }

        private static void CheckOrderResponseError(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine($"Response error: {error}");
                Console.WriteLine();

                throw new Exception(error);
            }
        }

        private static (string, object) StrategyMapper(string snapshot)
        {
            return StrategyMapper(JsonSerializer.Deserialize<JsonElement>(snapshot));
        }

        private static (string, object) StrategyMapper(JsonElement strategy)
        {
            var strategyTest = strategy.Deserialize<BaseTest>();

            object strategyObject;
            string strategyType;

            switch (strategyTest.StrategyType)
            {
                case StrategyType.SIMPLE_ORDER:
                    {
                        strategyType = StrategyType.SIMPLE_ORDER.ToString();
                        strategyObject = strategy.Deserialize<SimpleOrder>();
                        break;
                    }
                case StrategyType.VWAP:
                    {
                        strategyType = StrategyType.VWAP.ToString();
                        strategyObject = strategy.Deserialize<VWAP>();
                        break;
                    }
                case StrategyType.TWAP:
                    {
                        strategyType = StrategyType.TWAP.ToString();
                        strategyObject = strategy.Deserialize<TWAP>();
                        break;
                    }
                case StrategyType.MARKET_ORDER:
                    {
                        strategyType = StrategyType.MARKET_ORDER.ToString();
                        strategyObject = strategy.Deserialize<MarketOrder>();
                        break;
                    }
                case StrategyType.POV:
                    {
                        strategyType = StrategyType.POV.ToString();
                        strategyObject = strategy.Deserialize<POV>();
                        break;
                    }
                case StrategyType.PEGGED:
                    {
                        strategyType = StrategyType.PEGGED.ToString();
                        strategyObject = strategy.Deserialize<Pegged>();
                        break;
                    }
                case StrategyType.SNIPER:
                    {
                        strategyType = StrategyType.SNIPER.ToString();
                        strategyObject = strategy.Deserialize<Sniper>();
                        break;
                    }
                case StrategyType.ICEBERG:
                    {
                        strategyType = StrategyType.ICEBERG.ToString();
                        strategyObject = strategy.Deserialize<Iceberg>();
                        break;
                    }
                case StrategyType.AUCTION_ORDER:
                    {
                        strategyType = StrategyType.AUCTION_ORDER.ToString();
                        strategyObject = strategy.Deserialize<AuctionOrder>();
                        break;
                    }
                case StrategyType.FRA_INCLINATION:
                    {
                        strategyType = StrategyType.FRA_INCLINATION.ToString();
                        strategyObject = strategy.Deserialize<FRAInclination>();
                        break;
                    }
                case StrategyType.SPREAD4:
                case StrategyType.SPREAD3:
                case StrategyType.SPREAD:
                    {
                        strategyType = StrategyType.SPREAD.ToString();
                        strategyObject = strategy.Deserialize<Spread>();
                        break;
                    }
                case StrategyType.DI_SPREAD4:
                case StrategyType.DI_SPREAD3:
                case StrategyType.DI_SPREAD:
                    {
                        strategyType = StrategyType.DI_SPREAD.ToString();
                        strategyObject = strategy.Deserialize<DISpread>();
                        break;
                    }
                case StrategyType.FRA_SPREAD4:
                case StrategyType.FRA_SPREAD3:
                case StrategyType.FRA_SPREAD:
                    {
                        strategyType = StrategyType.FRA_SPREAD.ToString();
                        strategyObject = strategy.Deserialize<FRASpread>();
                        break;
                    }
                default:
                    {
                        strategyType = StrategyType.TICKET.ToString();
                        strategyObject = strategy.Deserialize<Ticket>();
                        break;
                    }
            }

            return (strategyType, strategyObject);
        }

        private static Dictionary<string, List<object>> StrategyMapper(List<JsonElement> strategyList)
        {
            Dictionary<string, List<object>> strategyResponseByType = new();

            if (strategyList != null && strategyList.Any())
            {
                foreach (var strategy in strategyList)
                {
                    var result = StrategyMapper(strategy);
                    strategyResponseByType.TryAdd(result.Item1, new());
                    strategyResponseByType[result.Item1].Add(result.Item2);
                }
            }

            return strategyResponseByType;
        }
    }
}
