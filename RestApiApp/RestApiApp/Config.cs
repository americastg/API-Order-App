using System.Configuration;

namespace RestApiApp
{
    internal static class Config
    {
        internal static readonly string BaseAddress = ConfigurationManager.AppSettings[nameof(BaseAddress)];
        internal static readonly string TokenAddress = ConfigurationManager.AppSettings[nameof(TokenAddress)];
        internal static readonly string ClientID = ConfigurationManager.AppSettings[nameof(ClientID)];
        internal static readonly string ClientSecret = ConfigurationManager.AppSettings[nameof(ClientSecret)];
        internal static readonly string Scope = ConfigurationManager.AppSettings[nameof(Scope)];
        internal static readonly string Username = ConfigurationManager.AppSettings[nameof(Username)];
        internal static readonly string Password = ConfigurationManager.AppSettings[nameof(Password)];
        internal static readonly string Broker = ConfigurationManager.AppSettings[nameof(Broker)];
        internal static readonly string Account = ConfigurationManager.AppSettings[nameof(Account)];
    }
}