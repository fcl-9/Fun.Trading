using Fun.Trading.Api.Controllers.YourNamespace.Controllers;

namespace Fun.Trading.UI.Services
{
    public interface IApiClient
    {
        Task<List<AccountResponse>> GetAccountsAsync();
        Task<AccountResponse?> GetAccountByIdAsync(int id);
    }
}