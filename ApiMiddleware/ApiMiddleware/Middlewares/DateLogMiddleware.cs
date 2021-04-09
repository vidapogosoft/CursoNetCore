using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace ApiMiddleware.Middlewares
{
    public class DateLogMiddleware
    {

        private readonly RequestDelegate _next;

        public DateLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke (HttpContext httpContext)
        {
            Debug.WriteLine("Access Time vpr:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            return _next(httpContext);

        }
    }

    public static class DateLogMiddlewareExtension
    {
        public static IApplicationBuilder UseDateLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DateLogMiddleware>();
        }
    }

}
