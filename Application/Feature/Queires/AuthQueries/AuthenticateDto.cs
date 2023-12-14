using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Queires.AuthQueries
{
    public record AuthenticateDto(string username, string Token);
}
