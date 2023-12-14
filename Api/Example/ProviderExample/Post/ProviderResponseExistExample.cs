using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Post
{
    public class ProviderResponseExistExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>("Proveedor con NIT 12345 ya existe.");
            yield return SwaggerExample.Create("Example existing Provider", response);
        }
    }
}
