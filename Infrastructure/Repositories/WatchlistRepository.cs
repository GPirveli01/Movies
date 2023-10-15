using Movies.Domain.Entities;
using Movies.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    public class WatchlistRepository : BaseRepository<Watchlist>, IWatchlistRepository
    {
        public WatchlistRepository(MoviesDbContext context) : base(context)
        {
        }
    }
}
