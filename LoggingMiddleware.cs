// Middleware (LoggingMiddleware.cs)
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
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
        catch (Exception ex)
        {
            LogExceptionToFile(ex);
            throw;
        }
    }

    private void LogExceptionToFile(Exception ex)
    {
        string logFilePath = "error.log";
        using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
        {
            writer.WriteLine($"[{DateTime.UtcNow}] An error occurred: {ex.Message}");
            writer.WriteLine($"StackTrace: {ex.StackTrace}");
            writer.WriteLine();
        }
    }
}
