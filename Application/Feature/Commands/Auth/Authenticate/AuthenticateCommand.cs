using Application.Common.Wrappers;
using Application.Feature.Queires.AuthQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Commands.Auth.Authenticate
{
    public record AuthenticateCommand(string UserName, string Password):IRequest<Response<AuthenticateDto>>;

    
}
