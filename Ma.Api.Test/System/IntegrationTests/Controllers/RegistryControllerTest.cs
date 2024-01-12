using System.Net;
using FluentAssertions;
using Ma.Api.Test.Fixtures;
using Ma.Api.Test.Fixtures.Dtos;
using Ma.Api.Test.Helpers;
using Refit;

namespace Ma.Api.Test.System.IntegrationTests.Controllers;

public class RegistryControllerTest: IClassFixture<WebApplicationFixture>
{

    private string BaseUri => EndpointsHelper.RegistriesEndpoint;
    private readonly WebApplicationFixture _factory;
    private readonly IRegistriesApi _registriesApi;
    public RegistryControllerTest(WebApplicationFixture factory)
    {
        _factory = factory;
        _registriesApi = RestService.For<IRegistriesApi>(_factory.Client);

    }


    [Fact]
    public async Task TestGet_WhenNotFound_ShouldReturns404()
    {
        // Arrange
        var client = _factory.Client;

        // Act
        const int id = 1;
        var response = await client.GetAsync($"{BaseUri}{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }


    [Fact]
    public async Task TestPost_WhenCreated_Returns201()
    {
        // Arrange
        var createRegistryDto = RegistryDtoFixtures.CreateRegistryDtoFixture();

        // Act
        var response = await _registriesApi.CreateRegistryAsync(createRegistryDto);

        // Assert
        response.Content?.Email.Should().Be(createRegistryDto.Email);
        response.Content?.Name.Should().Be(createRegistryDto.Name);
        response.Content?.Image.Should().Be(createRegistryDto.Image);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }



    [Fact]
    public async Task TestGet_WhenSuccess_ShouldReturns201()
    {
        // Arrange
        var createRegistryDto = RegistryDtoFixtures.CreateRegistryDtoFixture();

        // Act
        var createRegistryResponse = await _registriesApi.CreateRegistryAsync(createRegistryDto);
        var readRegistryResponse = await _registriesApi.GetRegistryAsync(createRegistryResponse.Content!.Id);

        // Assert
        createRegistryResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        readRegistryResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }



}