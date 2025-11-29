using System;
using Mapster;
using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Fun.Trading.Api.Controllers.YourNamespace.Controllers;

namespace Fun.Trading.Api
{
    public static class MapsterConfig
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            // AccountRequest -> DbAccount
            config.NewConfig<AccountRequest, DbAccount>()
                .Map(dest => dest.OwnerId, src => src.OwnerId)
                .Map(dest => dest.AccountType, src => src.AccountType.ToString())
                .Map(dest => dest.Balance, src => src.Balance);

            // DbAccount -> AccountResponse
            config.NewConfig<DbAccount, AccountResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.OwnerId, src => src.OwnerId) // fixed mapping
                .Map(dest => dest.AccountType, src => ConvertAccountType(src.AccountType))
                .Map(dest => dest.Balance, src => src.Balance);
        }

        private static string ConvertAccountType(string src)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                return src ?? string.Empty;
            }

            // try parse to known enum (case-insensitive), fallback to original string
            return Enum.TryParse<AccountType>(src, ignoreCase: true, out var parsed)
                ? parsed.ToString()
                : src;
        }
    }
}
