using Application.Feature.Commands.Auth.Authenticate;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.Auth.Post
{
    public class AuthenticateRequestExample : IMultipleExamplesProvider<AuthenticateCommand>
    {
        public IEnumerable<SwaggerExample<AuthenticateCommand>> GetExamples()
        {
            yield return new SwaggerExample<AuthenticateCommand>
            {
                Name = "SuccessfulAuthentication",
                Summary = "Example of Successful Authentication",
                Value = new AuthenticateCommand("usuarioEjemplo","123456")
                
            };
        }
     }
}
