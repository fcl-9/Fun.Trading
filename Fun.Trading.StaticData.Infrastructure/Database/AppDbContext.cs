using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Ticker> Tickers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure model relationships, constraints, etc.
    }
}