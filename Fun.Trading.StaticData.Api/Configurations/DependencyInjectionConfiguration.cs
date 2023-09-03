using Fun.Trading.StaticData.Infrastructure.Database.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Fun.Trading.StaticData.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure Database
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(Program).Assembly.FullName))
            );
            services.AddScoped<ITickerRepository, TickerRepository>();

            //Configure Automapper
            services.AddAutoMapper(typeof(Program)); 
        }
    }
}
