using Ma.API.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ma.Api.Test.Fixtures;

public class WebApplicationFixture: IAsyncLifetime
{
    private readonly WebApplicationFactory<Program> _factory;

    public HttpClient Client { get; set; }

    public WebApplicationFixture()
    {
        _factory =  new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => {

                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("test");
                    });
                });
            });

        Client = _factory.CreateClient();
    }

    public async Task InitializeAsync()
    {
        using var scope = _factory.Services.CreateScope();
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureCreatedAsync();
        }
    }

    public async Task DisposeAsync()
    {
        using var scope = _factory.Services.CreateScope();
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureDeletedAsync();
        }
    }
}
