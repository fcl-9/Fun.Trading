using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using global::Fun.Trading.Api.Controllers.YourNamespace.Controllers;

namespace Fun.Trading.UI.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AccountResponse>> GetAccountsAsync()
        {
            var result = await _http.GetFromJsonAsync<List<AccountResponse>>("api/accounts");
            return result ?? new List<AccountResponse>();
        }

        public async Task<AccountResponse?> GetAccountByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<AccountResponse?>($"api/accounts/{id}");
        }
    }
}