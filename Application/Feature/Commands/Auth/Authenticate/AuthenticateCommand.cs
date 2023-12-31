﻿using Application.Common.Wrappers;
using Application.Feature.Queires.AuthQueries;
using MediatR;

namespace Application.Feature.Commands.Auth.Authenticate
{
    public record AuthenticateCommand(string UserName, string Password):IRequest<Response<AuthenticateDto>>;

    
}
