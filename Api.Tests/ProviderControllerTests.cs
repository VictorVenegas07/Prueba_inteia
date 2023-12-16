using Api.Controllers;
using Application.Common.Wrappers;
using Application.Feature.Commands.Provider.CraeteProvider;
using Application.Feature.Commands.Provider.DaleteProvider;
using Application.Feature.Commands.Provider.UpdateProvider;
using Application.Feature.Queires.ProviderQueries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Tests
{
    public class ProviderControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ProviderController _controller;

        public ProviderControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProviderController(_mediatorMock.Object); ;
        }

        [Fact]
        public async void Post_Should_Return_Ok_With_CreateCommand()
        {
            // Arrange
            var companyInfo = new CreateCompanyCommand(
                CompanyName: "Mi Empresa",Addressstring: "123 Calle Principal",
                City: "Ciudad Ejemplo",Department: "Departamento Ejemplo",
                Email: "info@miempresa.com");
            var contactInfo = new CraeteContactCommand(ContactName: "Juan Pérez",ContactEmail: "juan.perez@miempresa.com");
            var command = new CraeteProviderCommand(NIT: 123456789, CompanyInfo: companyInfo, ContactInfo: contactInfo);

            var expectedResult = new Response<string>("657a4bb67f2a33834ec263c3", "Se registró exitosamente");

            _mediatorMock.Setup(x => x.Send(command,CancellationToken.None)).ReturnsAsync(expectedResult);
            // Act
            var result = await _controller.Post(command);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedResult, okResult.Value);
        }

        [Fact]
        public async void Get_Should_Return_Ok_With_Provider_List()
        {
           // Arrange
            var expectedResult = new Response<List<GetAllProvidersDto>> { Data = new List<GetAllProvidersDto> { } };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllProviders>(), CancellationToken.None)).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedResult, okResult.Value);
        }

        [Fact]
        public async void Put_Should_Return_Ok_With_Valid_UpdateCommand()
        {
            // Arrange
            var expectedResult = new Response<string>("Se actualizó correctamente.");
            var id = "657a4bb67f2a33834ec263c3";
            var command = new UpdateProviderCommand
             (Id: "657a4bb67f2a33834ec263c3",
             true,
              CompanyInfo: new UpdateCompanyCommand("Nuevo Nombre de la Compañía","Nueva Dirección","Nueva Ciudad","Nuevo Departamento","nuevo@correo.com"),
              ContactInfo: new UpdateContactCommand("Nuevo Nombre de Contacto","nuevocontacto@correo.com")
             );
            _mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.Put(id, command);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedResult, okResult.Value);
        }
        [Fact]
        public async void Delete_Should_Return_Ok_With_Valid_DeleteCommand()
        {
            // Arrange
            var expectedResult = new Response<string>("Se eliminó correctamente.");
            var command = new DaleteProviderCommand("657a4bb67f2a33834ec263c3");
            _mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.Delete(command.Id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedResult, okResult.Value);
        }
        

    }
}