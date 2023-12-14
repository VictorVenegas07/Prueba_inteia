using Application.Common.Wrappers;
using Application.Feature.Queires.AuthQueries;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Commands.Auth.Authenticate
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticateDto>>
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthenticateCommandHandler(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<Response<AuthenticateDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
           var user = await _userService.AuthenticateAsync(request.UserName, request.Password);
           var token = await _authService.GenerateTokenAsync(user);
            return new Response<AuthenticateDto>(new AuthenticateDto(user.UserName, token), Message.AuthenticatedUser);
        }
    }
}
