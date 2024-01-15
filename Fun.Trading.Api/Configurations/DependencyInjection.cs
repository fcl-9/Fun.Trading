using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fun.Trading.Api.DependencyInjectionConfigurations
{
    public static class DependencyInjection
    {
        public static void ConfigureAuthServices(this IServiceCollection services, IConfiguration configuration) {
        }
    }
}
