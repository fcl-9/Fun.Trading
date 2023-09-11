using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;

namespace Fun.Trading.StaticData.Infrastructure.Database.Repository
{
    public interface ITickerRepository
    {
        Task AddTickerAsync(Ticker ticker);
        Task<List<Ticker>> GetAllTickersAsync();
        Task<Ticker> GetTickerBySymbolAsync(string tickerSymbol);
    }
}