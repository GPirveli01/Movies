using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Features.Watchlist.Command;
using Movies.Application.Features.Watchlist.Commands;
using Movies.Application.Features.Watchlist.Queries;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistController : BaseController
    {
        [HttpGet("watchlists")]
        public async Task<IActionResult> GetWatchlistsByUserId([FromQuery] GetUserWatchlistItemsQuery query) => Ok(await Mediator.Send(query));

        [HttpPost("create-watchlist")]
        public async Task<IActionResult> CreateWatchlistItem(CreateWatchlistItemCommand comand) => Ok(await Mediator.Send(comand));

        [HttpPut("mark-watchlist-seen")]
        public async Task<IActionResult> MarkWatchlistItemAsSeen(MarkWatchlistAsSeenCommand command) => Ok(await Mediator.Send(command));
    }
}
