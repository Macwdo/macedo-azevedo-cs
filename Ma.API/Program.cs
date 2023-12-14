using Ma.API.Data;
using Ma.API.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.WebHost.UseSentry();
// builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

var connectionString = builder.Configuration.GetConnectionString("postgres");
builder.Services.AddNpgsql<ApplicationContext>(connectionString);

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();