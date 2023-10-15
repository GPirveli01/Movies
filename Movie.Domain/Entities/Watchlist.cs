using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Watchlist : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public bool Seen { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
