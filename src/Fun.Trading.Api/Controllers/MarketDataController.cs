using Microsoft.AspNetCore.Mvc;

namespace Fun.Trading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataController : ControllerBase
    {
        /// <summary>
        /// Gets a list of available market symbols
        /// </summary>
        /// <returns>Returns a list of available market symbols</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public IActionResult GetMarkets()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Real time market data
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Returns real-time market data for a specific symbol.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{symbol}")]
        public IActionResult GetMarketData(string symbol)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Historical market data for a specific symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Returns historical market data for a specific symbol.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{symbol}/history")]
        public IActionResult GetMarketDataHistory(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
