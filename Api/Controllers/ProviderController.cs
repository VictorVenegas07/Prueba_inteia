using Amazon.Runtime.Internal;
using Application.Common.Wrappers;
using Application.Feature.Commands.Provider.CraeteProvider;
using Application.Feature.Commands.Provider.DaleteProvider;
using Application.Feature.Commands.Provider.UpdateProvider;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class ProviderController : BaseApiController
    {
        private readonly IRepository<Provider> _repository;

        public ProviderController(IRepository<Provider> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="command">Datos del proveedor a crear.</param>
        /// <returns>Respuesta con información del resultado.</returns>
        [HttpPost]
        //[SwaggerResponseExample(400, typeof(ErrorResponse))]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public async Task<IActionResult> Post(CraeteProviderCommand command) => Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateProviderCommand command) => (id != command.Id)? BadRequest(): Ok(await Mediator.Send(command)) ;


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)=> Ok(await Mediator.Send(new DaleteProviderCommand(id)));
        


    }
}
