using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.DTOs.Responses.Watchlist
{
    public record WatchlistResponse(Guid Id, Guid MovieId, string MovieName, bool Seen);
}
