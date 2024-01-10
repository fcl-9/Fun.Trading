namespace Fun.Trading.Api.Controllers
{
    using AutoMapper;
    using Fun.Trading.Api.Accounts.Models;
    using Fun.Trading.Infrastructure.Database.DatabaseModel;
    using Microsoft.AspNetCore.Mvc;
    using System;

    namespace YourNamespace.Controllers
    {
        [Route("api/accounts")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            private readonly IAcountRepository accountRepository;
            private readonly IMapper mapper;

            public AccountController(IAcountRepository accountRepository, IMapper mapper)
            {
                this.accountRepository = accountRepository;
                this.mapper = mapper;
            }

            [HttpPost]
            public async Task<IActionResult> CreateAccount(Account body)
            {
                var dbAccount = mapper.Map<Account, DbAccount>(body);
                var accountId = await accountRepository.CreateAccount(dbAccount);
                return Created(new Uri(Request.Path), accountId);
            }

            [HttpGet("owner/{ownerId}")]
            public async Task<IActionResult> GetAccountByOwner(int ownerId)
            {
                var accountsByOwnerId = await accountRepository.GetAccountByOwnerId(ownerId);
                var accounts = mapper.Map<IEnumerable<DbAccount>, IEnumerable<Account>>(accountsByOwnerId);
                return Ok(accounts);
            }

            [HttpGet("{accountId}/transactions")]
            public async Task<IActionResult> GetAccountTransactions(int accountId)
            {
                var dbTransactions = await accountRepository.GetTransactionsByAccount(accountId);
                var transactions = mapper.Map<IEnumerable<DbTransaction>, IEnumerable<Transaction>>(dbTransactions);
                return Ok(transactions);
            }
        }
    }
}
