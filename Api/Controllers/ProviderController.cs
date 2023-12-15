using Api.Example.ProviderExample.Delete;
using Api.Example.ProviderExample.Get;
using Api.Example.ProviderExample.Post;
using Api.Example.ProviderExample.Put;
using Application.Common.Wrappers;
using Application.Feature.Commands.Provider.CraeteProvider;
using Application.Feature.Commands.Provider.DaleteProvider;
using Application.Feature.Commands.Provider.UpdateProvider;
using Application.Feature.Queires.ProviderQueries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProviderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProviderController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="command">Datos del proveedor a crear.</param>
        /// <response code ="200">Devuelve el Id del registro creado con un mensage de registró exitosamente</response>
        /// <response code ="409">Devulve un menssaje donde valida la existencia del proveedor</response>
        /// <response code ="400">Paramaetros no validos</response>
        /// <returns>Respuesta con información del resultado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 409)]
        [ProducesResponseType(typeof(Response<string>), 400)]
        [SwaggerResponseExample(200, typeof(ProvideResponseExample))]
        [SwaggerResponseExample(409, typeof(ProviderResponseExistExample))]
        [SwaggerResponseExample(400, typeof(ProviderResponseErrorValidationExample))]
        [SwaggerRequestExample(typeof(CraeteProviderCommand), typeof(ProviderRequestExample))]
        public async Task<IActionResult> Post(CraeteProviderCommand command) => Ok(await _mediator.Send(command));

        /// <summary>
        /// Actualiza un proveedor.
        /// </summary>
        /// <param name="id">Identificador único del proveedor.</param>
        /// <param name="command">Datos del proveedor a actualizar.</param>
        /// <response code ="200">Devuelve un mensage de actualizó correctamente</response>
        /// <response code ="404">Devuelve un menssaje donde valida la existencia del proveedor</response>
        /// <response code ="400">Paramaetros no validos</response>
        /// <returns>Respuesta con información del resultado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 409)]
        [ProducesResponseType(typeof(Response<string>), 400)]
        [SwaggerResponseExample(200, typeof(ProvideResponseExample))]
        [SwaggerResponseExample(404, typeof(ProviderResponseNotFoundExample))]
        [SwaggerResponseExample(400, typeof(ProviderResponseValidationExample))]
        [SwaggerRequestExample(typeof(CraeteProviderCommand), typeof(ProviderPutRequestExample))]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateProviderCommand command) => (id != command.Id)? BadRequest(): Ok(await _mediator.Send(command)) ;

        /// <summary>
        /// Eliminar un proveedor.
        /// </summary>
        /// <param name="id">Identificador único del proveedor.</param>
        /// <response code ="200">Devuelve un mensage de eliminacion correcta</response>
        /// <response code ="404">Devuelve un menssaje donde valida la existencia del proveedor</response>
        /// <returns>Respuesta con información del resultado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 404)]
        [SwaggerResponseExample(200, typeof(ProviderDeleteResponseExample))]
        [SwaggerResponseExample(404, typeof(ProviderResponseNotFoundExample))]
        public async Task<IActionResult> Delete(string id)=> Ok(await _mediator.Send(new DaleteProviderCommand(id)));

        /// <summary>
        /// Obtiene la lista de todos los proveedores.
        /// </summary>
        /// <response code="200">Devuelve la lista de proveedores.</response>
        /// <returns>Respuesta con la lista de proveedores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response<List<GetAllProvidersDto>>), 200)]
        [SwaggerResponseExample(200, typeof(ProviderGetExample))]
        public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetAllProviders()));

    }
}
