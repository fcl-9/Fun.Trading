using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class AppDbContext : DbContext
{
    public DbSet<DbTicker> Tickers { get; set; }
    public DbSet<DbAccount> Accounts { get; set; }
    public DbSet<DbTransaction> Transactions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        try
        {
            // Ensure database and schema exist (useful for development without running migrations).
            Database.EnsureCreated();

            // Seed sample accounts at first run if none exist.
            if (!Accounts.Any())
            {
                Accounts.AddRange(
                    new DbAccount
                    {
                        Id = 1,
                        OwnerId = 1,
                        AccountType = "Checking",
                        Balance = 1250.75m
                    },
                    new DbAccount
                    {
                        Id = 2,
                        OwnerId = 1,
                        AccountType = "Savings",
                        Balance = 10000.00m
                    },
                    new DbAccount
                    {
                        Id = 3,
                        OwnerId = 2,
                        AccountType = "Brokerage",
                        Balance = 25500.40m
                    }
                );

                SaveChanges();
            }
        }
        catch (Exception ex)
        {
            // Keep initialization non-fatal; log to console for quick local debugging.
            Console.WriteLine($"AppDbContext initialization error: {ex.Message}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure model relationships, constraints, etc.
    }
}