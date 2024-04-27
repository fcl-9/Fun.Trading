using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<DbTicker> Tickers { get; set; }
    public DbSet<DbAccount> Accounts { get; set; }
    public DbSet<DbTransaction> Transactions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure model relationships, constraints, etc.
    }
}