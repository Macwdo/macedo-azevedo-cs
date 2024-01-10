using Ma.API.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ma.Api.Test.Helpers;

public static class WebApplicationFactoryHelper
{
    public static WebApplicationFactory<Program> GetFactory()
    {


        var factory = new WebApplicationFactory<Program>()
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

        using var scope = factory.Services.CreateScope();
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
        }

        return factory;
    }

}