using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fun.Trading.UI.Services;
using global::Fun.Trading.Api.Controllers.YourNamespace.Controllers;

namespace Fun.Trading.UI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IApiClient _apiClient;

        public AccountsController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            List<AccountResponse> accounts = await _apiClient.GetAccountsAsync();
            return View(accounts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var account = await _apiClient.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
    }
}