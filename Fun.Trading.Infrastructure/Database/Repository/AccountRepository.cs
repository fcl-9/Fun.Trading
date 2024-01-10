using Fun.Trading.Infrastructure.Database.DatabaseModel;

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
            return account.AccountId;
        }
    }
}