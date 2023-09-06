using Fun.Trading.Orders.Api.Model;
using Fun.Trading.Orders.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fun.Trading.Orders.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class TradingController : ControllerBase
    {
        private readonly ITradingService _tradingService;

        public TradingController(ITradingService tradingService)
        {
            _tradingService = tradingService;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder(OrderRequest model)
        {
            var result = await _tradingService.CreateOrderAsync(model);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
