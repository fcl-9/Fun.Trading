using Fun.Trading.Api.Controllers.YourNamespace.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Fun.Trading.App
{
    public interface ITradingClient
    {
        public Task<AccountResponse> GetAccountByOwnerId(int ownerId);
    }
    public class TradingClient: ITradingClient
    {
        private readonly HttpClient client;

        public TradingClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<AccountResponse?> GetAccountByOwnerId(int ownerId)
        {
            var response = await client.GetAsync($"api/accounts/owner/{ownerId}");
            return await response.Content.ReadFromJsonAsync<AccountResponse>() ;
        }
    }
}
