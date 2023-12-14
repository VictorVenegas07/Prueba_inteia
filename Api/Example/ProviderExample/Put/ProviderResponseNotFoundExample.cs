using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Put
{
    public class ProviderResponseNotFoundExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>("No se encontro este registro.");
            yield return SwaggerExample.Create("Example provider not found", response);
        }
    }
}
