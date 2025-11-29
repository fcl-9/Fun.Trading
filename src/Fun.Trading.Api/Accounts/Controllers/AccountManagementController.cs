namespace Fun.Trading.Api.Controllers
{
    using AutoMapper;
    using Fun.Trading.Infrastructure.Database.DatabaseModel;
    using Fun.Trading.Infrastructure.Database.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Transactions;
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
            public async Task<IActionResult> CreateAccount(AccountRequest body)
            {
                var dbAccount = mapper.Map<AccountRequest, DbAccount>(body);
                var accountId = await accountRepository.CreateAccount(dbAccount);
                return CreatedAtRoute(nameof(GetAccountById), accountId);
            }

            [HttpGet("{accountId}")]
            public async Task<IActionResult> GetAccountById(int accountId)
            {
                var dbAccount = await accountRepository.GetAccountById(accountId);
                if(dbAccount is null)
                {
                    return NotFound();
                }
                var account = mapper.Map<DbAccount, AccountResponse>(dbAccount);
                return Ok(account);
            }

            [HttpGet("owner/{ownerId}")]
            public async Task<IActionResult> GetAccountByOwner(int ownerId)
            {
                var accountsByOwnerId = await accountRepository.GetAccountByOwnerId(ownerId);
                var accounts = mapper.Map<IEnumerable<DbAccount>, IEnumerable<AccountResponse>>(accountsByOwnerId);
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
