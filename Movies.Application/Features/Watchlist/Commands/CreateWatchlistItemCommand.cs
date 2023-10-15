using FluentValidation;
using Mapster;
using MediatR;
using Movies.Application.DTOs.Responses;
using Movies.Domain.Entities;
using Movies.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Watchlist.Command
{
    public record CreateWatchlistItemCommand(Guid UserId, Guid MovieId) : IRequest<BaseResponse>;

    public class CreateWatchlistItemCommandValidator : AbstractValidator<CreateWatchlistItemCommand>
    {
        public CreateWatchlistItemCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull()
                                .NotEmpty()
                                .NotEqual(Guid.Empty);

            RuleFor(x => x.MovieId).NotNull()
                                .NotEmpty()
                                .NotEqual(Guid.Empty);
        }
    }

    public class CreateWatchlistItemCommandHandler : IRequestHandler<CreateWatchlistItemCommand, BaseResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateWatchlistItemCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<BaseResponse> Handle(CreateWatchlistItemCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.WatchlistRepository.Any(x => x.UserId == request.UserId && x.MovieId == request.MovieId))
            {
                return new BaseResponse(false, "Movie already in watchlist for that user");
            }

            var watchlist = request.Adapt<Movies.Domain.Entities.Watchlist>();

            await _uow.WatchlistRepository.Add(watchlist, cancellationToken);

            await _uow.Commit();

            return new BaseResponse(true, "Movie added to watchlist successfully");
        }
    }
}
