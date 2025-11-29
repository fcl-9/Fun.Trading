using Fun.Trading.Infrastructure.Database.DatabaseModel;

namespace Fun.Trading.Infrastructure.Database.Repository
{
    public interface IAcountRepository
    {
        public  Task<int> CreateAccount(DbAccount account);
        public Task<DbAccount?> GetAccountById(int accountId);
        public Task<IEnumerable<DbAccount>> GetAccountByOwnerId(int ownerId);
        public Task<IEnumerable<DbTransaction>> GetTransactionsByAccount(int accountId);
        public Task<IEnumerable<DbAccount>> GetAllAccounts();
    }
}