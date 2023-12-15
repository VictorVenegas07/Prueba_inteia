using Application.Common.Wrappers;
using Application.Feature.Queires.AuthQueries;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.Auth.Post
{
    public class AuthenticateResponseExample : IMultipleExamplesProvider<Response<AuthenticateDto>>
    {
        public IEnumerable<SwaggerExample<Response<AuthenticateDto>>> GetExamples()
        {
            yield return new SwaggerExample<Response<AuthenticateDto>>
            {
                Name = "SuccessfulAuthentication",
                Summary = "Ejemplo de autenticación exitosa",
                Value = new Response<AuthenticateDto>
                {
                    Succeeded = true,
                    Message = "Usuario autenticado",
                    Data = new AuthenticateDto(
                         "vvenegas",
                         "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY1N2E3ODRlYzcwMDllZGI3ZGQxMDFlNiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJ2dmVuZWdhcyIsImV4cCI6MTcwMjYwOTgxOSwiaXNzIjoiUFJVRUJBVEVDTklDQUlTU1VFUiIsImF1ZCI6IlBSVUVCQVRFQ05JQ0FBVURJRU5DRSJ9.JrpDZjnVYqN8nsvosJ_Mc8smdfY-YHd_CePPMxVyLgQ"
                   ),
                    Errors = null
                }
            };
        }
    }
}
