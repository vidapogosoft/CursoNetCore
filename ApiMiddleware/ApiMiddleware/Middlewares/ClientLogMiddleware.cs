using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace ApiMiddleware.Middlewares
{

    public class ClientLogMiddleware
    {

        private readonly RequestDelegate _next;

        public ClientLogMiddleware (RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            var url = httpContext.Request.Path;

            Debug.WriteLine("urlvpr: " + url);
            Debug.WriteLine("ipAddressvpr: " + ipAddress);

            return _next(httpContext);
        }

    }

    public static class ClientLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseClientLogMiddleware (this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<ClientLogMiddleware>();

        }
    }
}
