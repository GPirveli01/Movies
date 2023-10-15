using FluentValidation;
using MediatR;
using Movies.Application.DTOs.Responses;
using Movies.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Watchlist.Commands
{
    public record MarkWatchlistAsSeenCommand(Guid WatchlistId) : IRequest<BaseResponse>;

    public class MarkWatchlistAsSeenCommandValidator : AbstractValidator<MarkWatchlistAsSeenCommand>
    {
        public MarkWatchlistAsSeenCommandValidator()
        {
            RuleFor(x => x.WatchlistId).NotNull()
                                   .NotEmpty()
                                   .NotEqual(Guid.Empty);
        }
    }

    public class MarkWatchlistAsSeenCommandHandler : IRequestHandler<MarkWatchlistAsSeenCommand, BaseResponse>
    {
        private readonly IUnitOfWork _uow;

        public MarkWatchlistAsSeenCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<BaseResponse> Handle(MarkWatchlistAsSeenCommand request, CancellationToken cancellationToken)
        {
            var watchlistItem = await _uow.WatchlistRepository.GetById(request.WatchlistId);

            watchlistItem.Seen = true;

            await _uow.Commit();

            return new BaseResponse(true, "Marked as seen successfully");
        }
    }
}
