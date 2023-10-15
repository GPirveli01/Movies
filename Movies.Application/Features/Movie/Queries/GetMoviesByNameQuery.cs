using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Application.DTOs.Responses.Movie;
using Movies.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Movie.Queries
{
    public record GetMoviesByNameQuery(string Name) : IRequest<List<MovieResponse>>;


    public class GetMoviesByNameQueryValidator : AbstractValidator<GetMoviesByNameQuery>
    {
        public GetMoviesByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotNull()
                                .NotEmpty();
        }
    }
    public class GetMoviesByNameQueryHandler : IRequestHandler<GetMoviesByNameQuery, List<MovieResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetMoviesByNameQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<MovieResponse>> Handle(GetMoviesByNameQuery request, CancellationToken cancellationToken)
        {
            var movies = await _uow.MovieRepository.GetAllWhere(x => x.Name.ToLower().Contains(request.Name.ToLower()))
                                                   .ToListAsync();

            var moviesResponse = movies.Adapt<List<MovieResponse>>();

            return moviesResponse;
        }
    }
}
