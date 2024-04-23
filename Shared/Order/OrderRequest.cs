namespace Fun.Trading.Orders.Api.Model
{
    public class OrderRequest
    {
        public required string Symbol { get; set; }
        public OrderType Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public enum OrderType
    {
        Buy,
        Sell
    }
}
