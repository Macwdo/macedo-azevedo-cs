using System.Net;
using FluentAssertions;
using Ma.API.Repository;
using Ma.Api.Test.Fixtures;
using Ma.Api.Test.Fixtures.Dtos;
using Ma.Api.Test.Helpers;
using Refit;

namespace Ma.Api.Test.System.IntegrationTests.Controllers;

public class RegistryControllerTest: IClassFixture<WebApplicationFixture>
{

    private string _baseUri { get; set; }
    private readonly WebApplicationFixture _factory;
    private readonly IRegistriesApi _registriesApi;
    public RegistryControllerTest(WebApplicationFixture factory)
    {
        _factory = factory;
        _registriesApi = RestService.For<IRegistriesApi>(_factory.Client);
        _baseUri = EndpointsHelper.RegistriesEndpoint;

    }


    [Fact]
    public async Task TestGet_WhenNotFound_ShouldReturns404()
    {
        // Arrange
        var client = _factory.Client;

        // Act
        const int id = 1;
        var response = await client.GetAsync($"{_baseUri}/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }


    [Fact]
    public async Task TestGet_WhenSuccess_ShouldReturns201()
    {
        // Arrange
        const int id = 1;
        var createRegistryDto = RegistryDtoFixtures.CreateRegistryDtoFixture();


        // Act
        var createRegistryResponse = await _registriesApi.CreateRegistryAsync(createRegistryDto);
        var readRegistryResponse = await _registriesApi.GetRegistryAsync(id);
        var readRegistriesResponse = await _registriesApi.GetRegistriesAsync();

        // Assert
        createRegistryResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        readRegistryResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

}