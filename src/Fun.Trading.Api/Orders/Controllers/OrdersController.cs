using Fun.Trading.Orders.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fun.Trading.Api.Orders.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {

        public OrdersController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of open orders for the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a specific order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a specific order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a specific order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
