namespace Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel
{
    public class DbTicker
    {
        public int Id { get; set; }
        public required string Symbol { get; set; }
        public required string CompanyName { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
    }
}
