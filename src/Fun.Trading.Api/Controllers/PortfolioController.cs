using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fun.Trading.Api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    [Authorize(Roles = "User")] // Requires user role for access
    public class PortfolioController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the current portfolio for the user.</returns>
        [HttpGet]
        public IActionResult GetPortfolio()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns historical portfolio data for the user.</returns>
        [HttpGet("history")]
        public IActionResult GetPortfolioHistory()
        {
            throw new NotImplementedException();
        }
    }
}
