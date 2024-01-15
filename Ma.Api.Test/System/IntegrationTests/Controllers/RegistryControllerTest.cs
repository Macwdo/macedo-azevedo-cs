using System.Net;
using FluentAssertions;
using Ma.API.Models.Registry;
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
    public async Task TaskGet_WhenSuccess_ShouldReturnsRegistries()
    {
        // Arrange
        var createRegistryDto = RegistryDtoFixtures.CreateRegistryDtoFixture();
        var createdRegistryResponse = await _registriesApi.CreateRegistryAsync(createRegistryDto);

        // Act
        var response = await _registriesApi.GetRegistriesAsync();

        // Assert
        response.Content.Should().BeEquivalentTo(new List<ReadRegistryDto>{createdRegistryResponse.Content!});
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

    [Theory]
    [InlineData("aa", "wrongemail", HttpStatusCode.BadRequest)]
    [InlineData("goodname", "somemail@mail.com", HttpStatusCode.Created)]
    public async Task WhenPost_OnValidBody_ShouldCreate(string name, string email, HttpStatusCode statusCode)
    {
        // Arrange
        var createRegistryDto = RegistryDtoFixtures.CreateRegistryDtoFixture();

        createRegistryDto.Email = email;
        createRegistryDto.Name = name;
        // Act
        var response = await _registriesApi.CreateRegistryAsync(createRegistryDto);

        // Assert
        response.StatusCode.Should().Be(statusCode);
    }

    [Fact]
    public async Task TestPost_WhenCreated_Returns201()
    {
        // Arrange
        var createRegistryDto = RegistryDtoFixtures.CreateRegistryDtoFixture();

        // Act
        var response = await _registriesApi.CreateRegistryAsync(createRegistryDto);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }



    // Update
    // public async Task Test
    // Delete


}
