namespace Fun.Trading.Orders.Api.Model
{
    public class OrderResponse
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
    }
}
