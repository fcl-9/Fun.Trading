using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;

namespace Fun.Trading.StaticData.Infrastructure.Database.Repository
{
    public interface ITickerRepository
    {
        Task AddTickerAsync(DbTicker ticker);
        Task<List<DbTicker>> GetAllTickersAsync();
        Task<DbTicker?> GetTickerBySymbolAsync(string tickerSymbol);
    }
}