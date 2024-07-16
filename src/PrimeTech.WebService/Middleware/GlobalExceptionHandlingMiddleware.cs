using System.Text.Json;

namespace PrimeTech.Interview.Business.Infrastructure.Middleware;

public sealed class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex, "Validation error occurred");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var errors = new
            {
                Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errors));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { Error = "An error occurred. Please try again later." }));
        }
    }
}

