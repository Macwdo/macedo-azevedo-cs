using FluentValidation;
using Ma.Api.Validators.Registry;
using Ma.API.Clients;
using Ma.API.Data;
using Ma.API.Middlewares;
using Ma.API.Models.Registry;
using Ma.API.Repository;
using Ma.API.Services;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ma.API;

public class Startup
{

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        #region Controllers
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        #endregion

        #region Loggers
        ConfigureLogging(services);

        #endregion

        #region Services DI

        services.AddHttpClient<IApiHelper, ApiHelper>(client => {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
        });



        ConfigureDiServices(services);

        #endregion

        #region Middlewares
        ConfigureMiddlewares(services);

        #endregion

        #region Database
        ConfigureDatabase(services);

        #endregion

        #region AutoMapper
        ConfigureAutoMapper(services);

        #endregion

    }

    private void ConfigureLogging(IServiceCollection services)
    {
        // services.AddApplicationInsightsTelemetry();
    
       Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

        // TODO: Test better log solution ELK, Sentry or ApplicationInsights;             
        // ConfigureLogging(services);
        // builder.WebHost.UseSentry();

    }

    private void ConfigureDiServices(IServiceCollection services)
    {
        services.AddScoped<IRegistryService, RegistryService>();
        services.AddScoped<ILawsuitService, LawsuitService>();
    }

    private void ConfigureValidators(IServiceCollection services){
        services.AddScoped<IValidator<CreateRegistryDto>, CreateRegistryDtoValidator>();
    }

    private void ConfigureMiddlewares(IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
    }

    private void ConfigureDatabase(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        var connectionString = Configuration.GetConnectionString("postgres");
        services.AddNpgsql<ApplicationContext>(connectionString);

    }

    private void ConfigureAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(s =>
        {
            s.MapControllers();
        });

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        # region Middlewares

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        # endregion


    }



}