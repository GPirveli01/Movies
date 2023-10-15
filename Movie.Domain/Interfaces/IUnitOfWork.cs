using Movies.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }
        IUserRepository UserRepository { get; }
        IWatchlistRepository WatchlistRepository { get; }
        Task Commit();
    }
}
