using AutoMapper;
using Fun.Trading.StaticData.Api.Model;
using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;
using Fun.Trading.StaticData.Infrastructure.Database.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Fun.Trading.StaticData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private readonly ITickerRepository repository;
        private readonly IMapper mapper;

        public TickerController(ITickerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TickerResponse>>> GetTickersAsync()
        {
            var tickers = await repository.GetAllTickersAsync();
            var tickersResponse = mapper.Map<IEnumerable<TickerResponse>>(tickers);
            return Ok(tickersResponse);
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<TickerResponse>> GetTickerAsync(string symbol)
        {
            var ticker = await repository.GetTickerBySymbolAsync(symbol);
            if (ticker == null)
            {
                return NotFound();
            }

            var tickerResponse = mapper.Map<TickerResponse>(ticker);
            return Ok(tickerResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTickerAsync(TickerRequest tickerRequest)
        {
            var ticker = mapper.Map<Ticker>(tickerRequest);
            await repository.AddTickerAsync(ticker);
            return CreatedAtAction(nameof(GetTickerAsync), new { symbol = ticker.Symbol }, ticker);
        }
    }
}
