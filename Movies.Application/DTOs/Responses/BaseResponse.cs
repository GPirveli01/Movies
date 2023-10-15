using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.DTOs.Responses
{
    public record BaseResponse(bool Success, string Message);
}
