using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Put
{
    public class ProviderResponseValidationExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>
            {
                Message = "Han ocurrido uno o más errores de validación",
                Errors = new List<string>
                {
                    "El identificador de la compañía no puede ser vacio.",
                    "El campo NIT no puede estar vacío.",
                    "El nombre de la compañía no puede estar vacío.",
                    "La dirección no puede estar vacía.",
                    "La ciudad no puede estar vacía.",
                    "El departamento no puede estar vacío.",
                    "El correo electrónico no puede estar vacío.",
                    "El formato del correo electrónico no es válido.",
                    "El nombre de contacto no puede estar vacío.",
                    "El correo electrónico de contacto no puede estar vacío.",
                    "El formato del correo electrónico de contacto no es válido."
                }
            };

            yield return SwaggerExample.Create("Example put response validators", response);
        }
    }
}
    

