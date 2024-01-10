using System.Net;
using FluentAssertions;
using Ma.Api.Test.Fixtures;
using Ma.Api.Test.Helpers;

namespace Ma.Api.Test.System.IntegrationTests.Controllers;

public class TestControllerRoutes: IClassFixture<WebApplicationFixture>
{

    private readonly WebApplicationFixture _factory;

    public TestControllerRoutes(WebApplicationFixture factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData(EndpointsHelper.RegistriesEndpoint)]
    [InlineData(EndpointsHelper.LawyersEndpoint)]
    [InlineData(EndpointsHelper.LawsuitsEndpoint)]
    public async Task TestGetAll_WhenSuccess_ThenReturnsOk(string route)
    {
        // Arrange
        var client = _factory.Client;
        // Act
        var response = await client.GetAsync(route);
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}