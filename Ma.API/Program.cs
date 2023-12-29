using Ma.API.Data;
using Ma.API.Middlewares;
using Ma.API.Repository;
using Ma.API.Services;

// TODO: Break this file into Startup.cs and Program.cs
var builder = WebApplication.CreateBuilder(args);

#region Controllers

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

// TODO: Add Serilog
#region Loggers

// builder.WebHost.UseSentry();
// builder.Services.AddApplicationInsightsTelemetry();

#endregion

#region Services DI

builder.Services.AddScoped<IRegistryService, RegistryService>();
builder.Services.AddScoped<ILawsuitService, LawsuitService>();

#endregion

#region Middlewares

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

#endregion

#region Database

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

var connectionString = builder.Configuration.GetConnectionString("postgres");
builder.Services.AddNpgsql<ApplicationContext>(connectionString);

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
# region Middlewares

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

# endregion

app.MapControllers();

app.Run();
