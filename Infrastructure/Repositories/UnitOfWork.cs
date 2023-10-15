using Movies.Domain.Interfaces;
using Movies.Domain.Interfaces.Repositories;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoviesDbContext _dbContext;
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;
        private IWatchlistRepository _watchlistRepository;

        public UnitOfWork(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IMovieRepository MovieRepository
        {
            get
            {
                _movieRepository ??= new MovieRepository(_dbContext);
                return _movieRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public IWatchlistRepository WatchlistRepository
        {
            get
            {
                _watchlistRepository ??= new WatchlistRepository(_dbContext);
                return _watchlistRepository;
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
