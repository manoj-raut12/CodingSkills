using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom middleware executed");

            await _next(context);
        }
    }

    // extension class
    public static class CustomerMiddelwareExtenstion
    {
        public static IApplicationBuilder UseCustomeMiddleware(this IApplicationBuilder app) 
        { 
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
