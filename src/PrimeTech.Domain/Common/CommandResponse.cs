using System;
using System.Collections.Generic;
using System.Net;

namespace PrimeTech.Interview.Business.Domain.Common;

public class CommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public DateTime Timestamp { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public CommandResponse()
    {
        Errors = [];
        Timestamp = DateTime.UtcNow;
        StatusCode = HttpStatusCode.OK;
        Success = true;
    }

    public CommandResponse(bool success, string message, List<string> errors = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        Success = success;
        Message = message;
        Errors = errors ?? [];
        Timestamp = DateTime.UtcNow;
        StatusCode = statusCode;
    }
}
