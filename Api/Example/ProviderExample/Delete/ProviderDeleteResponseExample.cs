using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Delete
{
    public class ProviderDeleteResponseExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>("Se eliminó correctamente.");
            yield return SwaggerExample.Create("Example delete response", response);
        }
    }
}
