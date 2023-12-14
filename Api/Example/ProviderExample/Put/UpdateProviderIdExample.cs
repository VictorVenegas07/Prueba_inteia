using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Put
{
    public class UpdateProviderIdExample : IMultipleExamplesProvider<string>
    {
        IEnumerable<SwaggerExample<string>> IMultipleExamplesProvider<string>.GetExamples()
        {
            yield return SwaggerExample.Create("Example id provider", "657a53195d04024da6b6efc1");
        }
    }
}
