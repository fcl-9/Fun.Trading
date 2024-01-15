using Fun.Trading.App.Auth0;
using Microsoft.Extensions.Logging;

namespace Fun.Trading.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "dev-z304ta23.eu.auth0.com",
                ClientId = "iubqG7shgozWEwfoLXt7CpDgKaxVBKCz",
                Scope = "openid profile",
                RedirectUri = "myapp://callback"
            }));

            builder.Services.AddHttpClient<ITradingClient, TradingClient>(c => c.BaseAddress = new Uri("http://192.168.0.23:5183"));

            return builder.Build();
        }
    }
}
