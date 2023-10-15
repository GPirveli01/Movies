using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.DTOs.Responses.Movie
{
    public record MovieResponse(Guid Id, string Name, DateTime CreateDate, DateTime? DeleteDate);
}
