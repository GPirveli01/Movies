using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Features.Movie.Queries;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        [HttpGet("movies")]
        public async Task<IActionResult> GetMoviesByName([FromQuery] GetMoviesByNameQuery query) => (Ok(await Mediator.Send(query)));


    }
}
