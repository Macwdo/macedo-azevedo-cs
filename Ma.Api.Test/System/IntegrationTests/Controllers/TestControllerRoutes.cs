using System.Net;
using FluentAssertions;
using Ma.API;
using Ma.Api.Test.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Ma.Api.Test.System.IntegrationTests.Controllers;

public class TestControllerRoutes
{

    private readonly WebApplicationFactory<Program> _factory;

    public TestControllerRoutes()
    {
        _factory = WebApplicationFactoryHelper.GetFactory();
    }

    [Theory]
    [InlineData("/api/v1/registries")]
    [InlineData("/api/v1/lawsuits")]
    [InlineData("/api/v1/lawyers")]
    public async Task WhenGetAll_ThenReturnsOk(string route)
    {
        // Arrange
        var client = _factory.CreateClient();
        // Act
        var response = await client.GetAsync(route);
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}