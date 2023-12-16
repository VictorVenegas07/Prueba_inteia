using Application.Feature.Commands.Provider.CraeteProvider;
using Application.Feature.Commands.Provider.UpdateProvider;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit.Abstractions;

namespace Api.Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private string _endpoint = "/api/Provider";
        private readonly ITestOutputHelper _output;

        public IntegrationTests(WebApplicationFactory<Program> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _client = _factory.CreateClient();
            _output = output;
        }
        private StringContent CreateJsonStringContent<T>(T command)
        {
            var jsonContent = JsonConvert.SerializeObject(command);
            return new StringContent(jsonContent, Encoding.UTF8, "application/json");
        }
        [Fact]
        public async Task Post_Endpoints_Return_Success_And_CorrectContentType()
        {
            // Arrange
            var companyInfo = new CreateCompanyCommand(
                  CompanyName: "Mi Empresa testeoo", Addressstring: "123 Calle Principal",
                  City: "Ciudad Ejemplo", Department: "Departamento Ejemplo",
                  Email: "info@miempresa.com");
            var contactInfo = new CraeteContactCommand(ContactName: "Juan Pérez", ContactEmail: "juan.perez@miempresa.com");
            var command = new CraeteProviderCommand(NIT: 344121934, CompanyInfo: companyInfo, ContactInfo: contactInfo);

            var content = CreateJsonStringContent<CraeteProviderCommand>(command);

            // Act
            var response = await _client.PostAsync(_endpoint, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }
        [Fact]
        public async Task Post_Endpoint_With_Incorrect_Content_Should_Return_BadRequest()
        {
            // Arrange

            var companyInfo = new CreateCompanyCommand(CompanyName: "", Addressstring: "", City: "", Department: "", Email: "");
            var contactInfo = new CraeteContactCommand(ContactName: "", ContactEmail: "");
            var command = new CraeteProviderCommand(NIT: 123459922, CompanyInfo: companyInfo, ContactInfo: contactInfo);

            var content = CreateJsonStringContent<CraeteProviderCommand>(command);

            // Act
            var response = await _client.PostAsync(_endpoint, content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");

        }
        [Fact]
        public async Task Post_Endpoint_With_Existing_NIT_Should_Return_Conflict()
        {
            // Arrange
            var companyInfo = new CreateCompanyCommand(CompanyName: "Mi Empresa testeoo", Addressstring: "123 Calle Principal",
                 City: "Ciudad Ejemplo", Department: "Departamento Ejemplo", Email: "info@miempresa.com");
            var contactInfo = new CraeteContactCommand(ContactName: "Juan Pérez", ContactEmail: "juan.perez@miempresa.com");
            var command = new CraeteProviderCommand(NIT: 123459922, CompanyInfo: companyInfo, ContactInfo: contactInfo);

            var content = CreateJsonStringContent<CraeteProviderCommand>(command);

            // Act
            var response = await _client.PostAsync(_endpoint, content);

            // Assert
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }

        [Fact]
        public async Task Put_Existing_ProviderId_Should_Return_Ok()
        {
            // Arrange
            var id = "657a4bb67f2a33834ec263c3";
            var command = new UpdateProviderCommand
             (Id: "657a4bb67f2a33834ec263c3",
                true,
              CompanyInfo: new UpdateCompanyCommand("Nuevo tests de la Compañía tests", "Nueva Dirección tests", "Nueva Ciudad tests", "Nuevo Departamento tests", "nuevo@tests.com"),
              ContactInfo: new UpdateContactCommand("Nuevo tests de Contacto", "nuevotests@correo.com")
             );

            var content = CreateJsonStringContent<UpdateProviderCommand>(command);

            // Act
            var response = await _client.PutAsync($"{_endpoint}/{id}", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }

        [Fact]
        public async Task Put_Non_existent_ProviderId_Should_Return_Conflict()
        {
            // Arrange
            var notExistId = "657a4bb67f2a33834ec999c3";
            var command = new UpdateProviderCommand
             (Id: "657a4bb67f2a33834ec999c3",
             true,
              CompanyInfo: new UpdateCompanyCommand("Nuevo tests de la Compañía tests", "Nueva Dirección tests", "Nueva Ciudad tests", "Nuevo Departamento tests", "nuevo@tests.com"),
              ContactInfo: new UpdateContactCommand("Nuevo tests de Contacto", "nuevotests@correo.com")
             );

            var content = CreateJsonStringContent<UpdateProviderCommand>(command);

            // Act
            var response = await _client.PutAsync($"{_endpoint}/{notExistId}", content);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }

        [Fact]
        public async Task Put_InvalidUpdateCommand_ShouldReturnBadRequest()
        {
            // Arrange
            var notExistId = "657a4bb67f2a33834ec263c3";
            var command = new UpdateProviderCommand
             (Id: "657a4bb67f2a33834ec263c3",
               true,
              CompanyInfo: null,
              ContactInfo: new UpdateContactCommand(null, "")
             );

            var content = CreateJsonStringContent<UpdateProviderCommand>(command);

            // Act
            var response = await _client.PutAsync($"{_endpoint}/{notExistId}", content);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }

        [Fact]
        public async Task Delete_ExistingProviderId_Should_Return_Ok()
        {
            // Arrange
            var ExistingProviderId = "657c8c454763cca706466f2a";

            // Act
            var response = await _client.DeleteAsync($"{_endpoint}/{ExistingProviderId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }
        [Fact]
        public async Task Delete_NonexistentProviderId_Should_Return_NotFound()
        {
            // Arrange
            var ExistingProviderId = "657c8c454763cca999999f2a";

            // Act
            var response = await _client.DeleteAsync($"{_endpoint}/{ExistingProviderId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }

        [Fact]
        public async Task Get_ReturnsListOfProviders_Should_Return_Ok()
        {
            //Arrange

            // Act
            var response = await _client.GetAsync(_endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // output
            _output.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            _output.WriteLine($"Status Code: {response.StatusCode}");
        }
    }
}
