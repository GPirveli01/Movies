using Movies.Domain.Entities;

namespace Movies.Infrastructure.Seed
{
    public static class DbInitializer
    {
        public static void SeedData(MoviesDbContext dbContext)
        {
            SeedMovies(dbContext);
            SeedUsers(dbContext);
            SeedWatchLists(dbContext);
        }
        private static void SeedMovies(MoviesDbContext dbContext)
        {
            if (!dbContext.Movies.Any())
            {
                var movies = new List<Movie>()
                {
                    new Movie()
                    {
                        Id = Guid.NewGuid(),
                        Name = "The Godfather",
                    },
                    new Movie()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Once Upon A Time In America",
                    },
                    new Movie()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Karate Kid",
                    },
                    new Movie()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Peola",
                    },
                    new Movie()
                    {
                        Id = Guid.NewGuid(),
                        Name = "The Amazing Spider-man",
                    },
                };

                dbContext.Movies.AddRange(movies);
                dbContext.SaveChanges();
            }
        }

        private static void SeedUsers(MoviesDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Giorgi",
                        LastName = "Pirveli",
                    },
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Davit",
                        LastName = "Davitashvili",
                    },
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Giorgi",
                        LastName = "Giorgadze",
                    },
                };

                dbContext.Users.AddRange(users);
                dbContext.SaveChanges();
            }
        }

        private static void SeedWatchLists(MoviesDbContext dbContext)
        {
            if (dbContext.Users.Any() && dbContext.Movies.Any() && !dbContext.Watchlist.Any())
            {
                var watchlists = new List<Watchlist>();
                foreach (var user in dbContext.Users.ToList())
                {
                    var randomMovie = dbContext.Movies.ToList().OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                    watchlists.Add(new Watchlist()
                    {
                        Id = Guid.NewGuid(),
                        MovieId = randomMovie.Id,
                        UserId = user.Id
                    });
                }

                dbContext.Watchlist.AddRange(watchlists);
                dbContext.SaveChanges();
            }
        }
    }
}
