namespace Fun.Trading.StaticData.Api.Model
{
    public class TickerResponse
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
    }
}
