using FluentAssertions;
using Ma.API.Controllers.Registry;
using Ma.API.DTOs.Registry;
using Ma.API.Services;
using Ma.Api.Test.Fixtures.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Ma.Api.Test.System.Controllers;

public class RegistriesControllerTest
{

    public RegistriesControllerTest()
    {
    }

    [Fact]
    public void GetAllRequest_OnSuccess_Returns200()
    {
        // Arrange
        var readRegistriesDtoFixture = RegistryDtoFixtures.ReadRegistriesDtoFixture(2, false);

        var mockedService = new Mock<IRegistryService>();
        mockedService
            .Setup(s => s.GetRegistries())
            .Returns(readRegistriesDtoFixture);

        var controller = new RegistriesController(mockedService.Object);

        // Act
        var controllerResult = (OkObjectResult)controller.GetAll();

        // Assert
        controllerResult.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetRequest_OnSuccess_Returns200()
    {
        // Arrange
        var readRegistryDtoFixture = RegistryDtoFixtures.ReadRegistryDtoFixture(1);

        var mockedService = new Mock<IRegistryService>();
        mockedService
            .Setup(s => s.GetRegistry(1))
            .Returns(readRegistryDtoFixture);

        var controller = new RegistriesController(mockedService.Object);
        // Act
        var controllerResult = (OkObjectResult)controller.Get(1);

        // Assert
        controllerResult.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetRequest_WhenNotFound_Returns404()
    {
        // Arrange

        ReadRegistryDto? readRegistryDto = null;
        var mockedService = new Mock<IRegistryService>();
        mockedService
            .Setup(s => s.GetRegistry(1))
            .Returns(readRegistryDto);

        var controller = new RegistriesController(mockedService.Object);
        // Act
        var controllerResult = (NotFoundResult)controller.Get(1);

        // Assert
        controllerResult.StatusCode.Should().Be(404);

    }




}