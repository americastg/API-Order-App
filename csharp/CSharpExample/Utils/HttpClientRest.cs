using IdentityModel.Client;
using System.Net.Http.Headers;

namespace CSharpExample.Utils
{
    public class HttpClientRest
    {
        private readonly HttpClient _client = new();

        public string Token { get; private set; }
        public HttpClient Client { get { return _client; } }

        public async Task GetAuthToken(Config config)
        {
            var client = new HttpClient();

            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = config.TokenAddress,
                ClientId = config.ClientId,
                ClientSecret = config.ClientSecret,
                Scope = "externalapi",
                UserName = config.UserName,
                Password = config.Password
            });

            if (response.IsError) throw new Exception($"Erro: [{response.Error}] | Status: [{response.HttpStatusCode}]");

            Token = response.AccessToken.ToString();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            _client.BaseAddress = new Uri(config.BaseAddress);

            Console.WriteLine("Token de acesso configurado");
        }
    }
}
