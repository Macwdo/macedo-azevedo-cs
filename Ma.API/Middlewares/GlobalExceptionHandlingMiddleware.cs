using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Ma.API.Middlewares;
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
                Detail = $"Error message: {e.Message}"
            };

            var json = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);


        }
    }
}
