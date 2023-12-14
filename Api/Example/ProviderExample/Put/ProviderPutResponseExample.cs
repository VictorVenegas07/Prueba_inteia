using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Put
{
    public class ProviderPutResponseExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>("Se actualizó correctamente");
            yield return SwaggerExample.Create("Example put response", response);
        }
    }
}
