using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Application.DTOs.Responses.Watchlist;
using Movies.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Watchlist.Queries
{
    public record GetUserWatchlistItemsQuery(Guid UserId) : IRequest<List<WatchlistResponse>>;

    public class GetUserWatchlistItemQueryValidator : AbstractValidator<GetUserWatchlistItemsQuery>
    {
        public GetUserWatchlistItemQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull()
                                  .NotEmpty()
                                  .NotEqual(Guid.Empty);
        }
    }

    public class GetUserWatchlistItemQueryHandler : IRequestHandler<GetUserWatchlistItemsQuery, List<WatchlistResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetUserWatchlistItemQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<WatchlistResponse>> Handle(GetUserWatchlistItemsQuery request, CancellationToken cancellationToken)
        {
            var watchlistItems = await _uow.WatchlistRepository.GetAllWhere(x => x.UserId == request.UserId)
                                                         .Include(x => x.Movie)
                                                         .ToListAsync();

            return watchlistItems.Adapt<List<WatchlistResponse>>();
        }
    }
}
