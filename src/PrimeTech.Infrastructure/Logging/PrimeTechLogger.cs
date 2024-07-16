using Microsoft.Extensions.Logging;
using PrimeTech.Interview.Business.Domain.Common;
using System;

namespace PrimeTech.Interview.Business.Infrastructure.Logging;

internal class PrimeTechLogger<T> : IPrimeTechLogger<T>
{

    private readonly ILogger<T> _logger;

    public PrimeTechLogger(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void LogDebug(string? message, params object?[] args)
    {
        _logger.LogDebug(message, args);
    }

    public void LogInformation(string? message, params object?[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string? message, params object?[] args)
    {
        _logger.LogWarning(message, args);
    }

    public void LogWarning(Exception? exception, string? message, params object?[] args)
    {
        _logger.LogWarning(exception, message, args);
    }

    public void LogError(Exception? exception, string? message, params object?[] args)
    {
        _logger.LogError(exception, message, args);
    }

    public void LogError(string? message, params object?[] args)
    {
        _logger.LogError(message, args);
    }

    public void LogTraceEvent(string eventName)
    {
        _logger.LogDebug("{TarceEvent} is successful", eventName);
    }
}

