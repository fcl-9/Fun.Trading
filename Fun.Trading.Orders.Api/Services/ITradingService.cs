using Fun.Trading.Orders.Api.Model;

namespace Fun.Trading.Orders.Api.Services
{
    public interface ITradingService
    {
        Task<OrderResponse> CreateOrderAsync(OrderRequest order);
    }
}
