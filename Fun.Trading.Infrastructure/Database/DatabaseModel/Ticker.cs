namespace Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel
{
    public class Ticker
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
    }
}
