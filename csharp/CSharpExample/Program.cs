using CSharpExample.Examples;
using CSharpExample.Utils;
using System.Text.Json;

#region Config

Config config;
using (StreamReader r = new("appsettings.json"))
{
    string json = r.ReadToEnd();
    config = JsonSerializer.Deserialize<Config>(json);
}

var httpClient = new HttpClientRest();
await httpClient.GetAuthToken(config);

#endregion

_ = new WebSocketExample(config.BaseAddress, httpClient.Token).RunAsync();
await new SimpleOrderExample(httpClient.Client, config).RunAsync();
await new SpreadExample(httpClient.Client, config).RunAsync();
await new TradingExample(httpClient.Client).RunAsync();

Console.WriteLine("Finished");
Console.ReadLine();
