using Application.Common.Wrappers;
using Application.Feature.Queires.ProviderQueries.GetAll;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Get
{
    public class ProvidersGetNoContentExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>("El recurso solicitado no contiene contenido.");
            yield return SwaggerExample.Create("Example provider not found", response);
        }
    }
}
