using FluentValidation;
using MediatR;
using Movies.Application;
using Movies.Application.Behaviors;
using Movies.Domain.Interfaces;
using Movies.Domain.Interfaces.Repositories;
using Movies.Infrastructure.Repositories;
using System.Reflection;

namespace Movies.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWatchlistRepository, WatchlistRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            var applicationAssembly = typeof(AssemblyReference).Assembly;
            services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
