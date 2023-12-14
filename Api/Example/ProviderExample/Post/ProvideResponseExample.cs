using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Post
{
    public class ProvideResponseExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            var response = new Response<string>("Se registró exitosamente", "657a53195d04024da6b6efc1");
            yield return SwaggerExample.Create("Example response", response);
        }
    }
}
