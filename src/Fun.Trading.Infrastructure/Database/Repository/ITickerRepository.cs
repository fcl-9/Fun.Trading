using Fun.Trading.Infrastructure.Database.DatabaseModel;

namespace Fun.Trading.Infrastructure.Database.Repository
{
    public interface ITickerRepository
    {
        Task AddTickerAsync(DbTicker ticker);
        Task<List<DbTicker>> GetAllTickersAsync();
        Task<DbTicker?> GetTickerBySymbolAsync(string tickerSymbol);
    }
}