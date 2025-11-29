using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Fun.Trading.Infrastructure.Database.Repository
{
    public class TickerRepository : ITickerRepository
    {
        private readonly AppDbContext _context;

        public TickerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DbTicker>> GetAllTickersAsync()
        {
            return await _context.Tickers.ToListAsync();
        }

        public async Task AddTickerAsync(DbTicker ticker)
        {
            _context.Tickers.Add(ticker);
            await _context.SaveChangesAsync();
        }

        public async Task<DbTicker?> GetTickerBySymbolAsync(string tickerSymbol)
        {
            return await _context.Tickers.SingleOrDefaultAsync(t => t.Symbol == tickerSymbol);
        }
    }
}
