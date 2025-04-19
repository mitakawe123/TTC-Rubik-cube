using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace RubiksCube.Application.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = exception.Message,
        };

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse), cancellationToken);
        return await Task.FromResult(true);    
    }
}