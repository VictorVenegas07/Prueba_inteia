using Application.Feature.Commands.Auth.Authenticate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AuthenticateController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AuthenticateCommand command) => Ok(await Mediator.Send(command));
    }
}
