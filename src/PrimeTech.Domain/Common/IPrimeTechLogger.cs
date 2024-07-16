using System;

namespace PrimeTech.Interview.Business.Domain.Common;

public interface IPrimeTechLogger<T> : IPrimeTechLogger
{

}

public interface IPrimeTechLogger
{
    void LogDebug(string? message, params object?[] args);

    void LogInformation(string? message, params object?[] args);

    void LogWarning(string? message, params object?[] args);

    void LogWarning(Exception? exception, string? message, params object?[] args);

    void LogError(Exception? exception, string? message, params object?[] args);

    void LogError(string? message, params object?[] args);

    void LogTraceEvent(string eventName);
}

