using Api.Example.Auth.Post;
using Application.Common.Wrappers;
using Application.Feature.Commands.Auth.Authenticate;
using Application.Feature.Queires.AuthQueries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers
{
    public class AuthenticateController : BaseApiController
    {
        /// <summary>
        /// Autentica a un usuario.
        /// </summary>
        /// <param name="command">Datos de autenticación del usuario.</param>
        /// <response code="200">Autenticación exitosa.</response>
        /// <response code="401">Credenciales inválidas.</response>
        /// <returns>Respuesta con información del resultado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 401)]
        [SwaggerResponseExample(200, typeof(AuthenticateResponseExample))]
        [SwaggerResponseExample(401, typeof(AuthenticateErrorResponseExample))]
        [SwaggerRequestExample(typeof(AuthenticateCommand), typeof(AuthenticateRequestExample))]
        public async Task<IActionResult> Auth(AuthenticateCommand command) => Ok(await Mediator.Send(command));
    }
}
