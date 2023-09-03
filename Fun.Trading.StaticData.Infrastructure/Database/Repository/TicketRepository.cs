using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Fun.Trading.StaticData.Infrastructure.Database.Repository
{
    public class TickerRepository : ITickerRepository
    {
        private readonly AppDbContext _context;

        public TickerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticker>> GetAllTickersAsync()
        {
            return await _context.Tickers.ToListAsync();
        }

        public async Task AddTickerAsync(Ticker ticker)
        {
            _context.Tickers.Add(ticker);
            await _context.SaveChangesAsync();
        }

        public async Task<Ticker> GetTickerBySymbolAsync(string tickerSymbol)
        {
            return await _context.Tickers.SingleOrDefaultAsync(t => t.Symbol == tickerSymbol);
        }
    }
}
