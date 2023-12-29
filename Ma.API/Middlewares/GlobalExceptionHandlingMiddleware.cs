using System.Net.Mime;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Ma.API.Middlewares;
// TODO: Make this work
public class GlobalExceptionHandlingMiddleware: IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;


    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ProblemDetails problem = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "Error",
                Title = "Internal Server Error",
                Detail = e.Message,
                Instance = context.Request.Path
            };

            var json = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(json);

            context.Response.ContentType = "application/json";

        }
    }
}
