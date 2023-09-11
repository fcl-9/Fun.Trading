namespace Fun.Trading.Api.DependencyInjectionConfigurations
{
    public class AuthOptions
    {
        public const string Auth = "Auth";
        public string Domain { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string Connection { get; set; } = string.Empty;
    }
}