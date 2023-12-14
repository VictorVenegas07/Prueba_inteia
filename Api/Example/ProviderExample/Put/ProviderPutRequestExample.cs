using Application.Feature.Commands.Provider.CraeteProvider;
using Application.Feature.Commands.Provider.UpdateProvider;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Put
{
    public class ProviderPutRequestExample : IMultipleExamplesProvider<UpdateProviderCommand>
    {
        public IEnumerable<SwaggerExample<UpdateProviderCommand>> GetExamples()
        {
            var example = new UpdateProviderCommand(
              Id: "657a53195d04024da6b6efc1",
              CompanyInfo: new UpdateCompanyCommand
              (
                  "Nuevo Nombre de la Compañía",
                  "Nueva Dirección",
                  "Nueva Ciudad",
                  "Nuevo Departamento",
                  "nuevo@correo.com"
              ),
              ContactInfo: new UpdateContactCommand
              (
                  "Nuevo Nombre de Contacto",
                  "nuevocontacto@correo.com"
              )
          );

            yield return SwaggerExample.Create("Example put provider", example);
        }
    }
}
