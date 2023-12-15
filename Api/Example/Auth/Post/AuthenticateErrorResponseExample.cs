using Application.Common.Wrappers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.Auth.Post
{
    public class AuthenticateErrorResponseExample : IMultipleExamplesProvider<Response<string>>
    {
        public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
        {
            yield return new SwaggerExample<Response<string>>
            {
                Name = "UnauthorizedAccess",
                Summary = "Example of Unauthorized Access",
                Value = new Response<string>
                {
                    Succeeded = false,
                    Message = "Las credenciales del usuario no son validas",
                }
            };
        }
    }
}
