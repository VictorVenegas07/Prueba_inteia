using Api.Controllers;
using Application.Feature.Commands.Provider.CraeteProvider;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var client = _factory.CreateClient();
            var endpoint = "/api/Provider";
            var companyInfo = new CreateCompanyCommand(
                  CompanyName: "Mi Empresa testeoo", Addressstring: "123 Calle Principal",
                  City: "Ciudad Ejemplo", Department: "Departamento Ejemplo",
                  Email: "info@miempresa.com");
            var contactInfo = new CraeteContactCommand(ContactName: "Juan Pérez", ContactEmail: "juan.perez@miempresa.com");
            var command = new CraeteProviderCommand(NIT: 1234561232, CompanyInfo: companyInfo, ContactInfo: contactInfo);
            var jsonContent = JsonConvert.SerializeObject(command);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(endpoint, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
