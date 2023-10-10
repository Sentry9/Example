namespace Loans.Application.Middleware;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ServiceNameMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _serviceName;

    public ServiceNameMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _serviceName = configuration["X_SERVICE_NAME"] ?? "DEFAULT";
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Add("X-SERVICE-NAME", _serviceName);

        await _next(context);
    }
}
