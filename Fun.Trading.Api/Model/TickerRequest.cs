namespace Fun.Trading.StaticData.Api.Model
{
    public class TickerRequest
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
    }
}
