using Ma.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ma.Api.Test.System.UnitTests.Middlewares;

public class GlobalExceptionHandlingMiddlewareTest{

    public GlobalExceptionHandlingMiddlewareTest()
    {
        
    }

    // WIP
    [Fact]
    public async Task GlobalExceptionHandlingMiddlewareTest_ReturnsInternalError()
    {

        // Arrange
        const string errorMessage = "Test Exception";

        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        services.AddControllers();
                        services.AddTransient<GlobalExceptionHandlingMiddleware>();

                    })
                    .Configure(app =>
                        {
                            app.UseRouting();
                            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

                            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
                        }
                    );
            })
            .StartAsync();

        ProblemDetails problem = new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "Error",
            Title = "Internal Server Error",
            Detail = errorMessage
        };

        // Act
        var response = await host.GetTestClient().GetAsync("/registries");

        // Assert
        // response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

    }
}

