using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Fun.Trading.Api.Controllers.YourNamespace.Controllers
{
    public class AccountRepository : IAcountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAccount(DbAccount account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account.Id;
        }

        public async Task<IEnumerable<DbAccount>> GetAccountByOwnerId(int ownerId)
        {
            var accounts = await _context.Accounts.Where(acc => acc.OwnerId == ownerId).ToListAsync();
            return accounts;
        }

        public async Task<IEnumerable<DbTransaction>> GetTransactionsByAccount(int accountId)
        {
            var account = await _context.Accounts.SingleAsync(acc => acc.Id == accountId);
            return account.Transactions.ToList();
        }
    }
}