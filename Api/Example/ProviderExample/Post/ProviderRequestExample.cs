using Application.Feature.Commands.Provider.CraeteProvider;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Example.ProviderExample.Post
{
    public class ProviderRequestExample : IMultipleExamplesProvider<CraeteProviderCommand>
    {
        public IEnumerable<SwaggerExample<CraeteProviderCommand>> GetExamples()
        {
            var companyInfo = new CreateCompanyCommand
             (
                 CompanyName: "Mi Empresa",
                 Addressstring: "123 Calle Principal",
                 City: "Ciudad Ejemplo",
                 Department: "Departamento Ejemplo",
                 Email: "info@miempresa.com"
             );

            var contactInfo = new CraeteContactCommand
            (
                ContactName: "Juan Pérez",
                ContactEmail: "juan.perez@miempresa.com"
            );

            yield return SwaggerExample.Create(
                "EjemploProvider",
                new CraeteProviderCommand(NIT: 123456789, CompanyInfo: companyInfo, ContactInfo: contactInfo)
            );
        }
    }
}
