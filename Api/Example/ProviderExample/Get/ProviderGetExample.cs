using Application.Common.Wrappers;
using Application.Feature.Queires.ProviderQueries.GetAll;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Get
{
    public class ProviderGetExample : IMultipleExamplesProvider<Response<List<GetAllProvidersDto>>>
    {
        public IEnumerable<SwaggerExample<Response<List<GetAllProvidersDto>>>> GetExamples()
        {
            yield return new SwaggerExample<Response<List<GetAllProvidersDto>>>
            {
                Name = "SuccessfulResponse",
                Summary = "Ejemplo de respuesta exitosa",
                Value = new Response<List<GetAllProvidersDto>>
                {
                    Succeeded = true,
                    Message = "Consulta exitosa",
                    Data = new List<GetAllProvidersDto>
                    {
                        new GetAllProvidersDto
                        {
                            Id = "657a4bb67f2a33834ec263c3",
                            NIT = 123456789,
                            Company = new Company
                            {
                                CompanyName = "Proveedor A",
                                Address = "Calle 123",
                                City = "Ciudad A",
                                Department = "Departamento A",
                                Email = "proveedorA@example.com"
                            },
                            Contact = new Contact
                            {
                                ContactName = "Contacto A",
                                ContactEmail = "contactoA@example.com"
                            },
                            IsActive = true
                        },
                        new GetAllProvidersDto
                        {
                            Id = "657a4bb67f2a33834ec263c3",
                            NIT = 987654321,
                            Company = new Company
                            {
                                CompanyName = "Proveedor B",
                                Address = "Calle 456",
                                City = "Ciudad B",
                                Department = "Departamento B",
                                Email = "proveedorB@example.com"
                            },
                            Contact = new Contact
                            {
                                ContactName = "Contacto B",
                                ContactEmail = "contactoB@example.com"
                            },
                            IsActive = true
                        }
                    }
                }
            };
        }
    }
}
