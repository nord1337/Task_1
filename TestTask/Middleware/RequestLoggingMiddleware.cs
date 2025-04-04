using Application.Interfaces;
using Domain.Entities;

namespace TestTask.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, IDbContext dbContext)
    {
        var log = new RequestLog
        {
            Method = context.Request.Method,
            Path = context.Request.Path,
            StartDate = DateTime.UtcNow
        };

        await _next(context);

        log.StatusCode = context.Response.StatusCode;
        log.EndDate = DateTime.UtcNow;

        try
        {
            dbContext.RequestLogs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error on saving RequestLog", ex);
        }
    }
}
