﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }

        public List<Watchlist> Watchlists { get; set; }
    }
}
