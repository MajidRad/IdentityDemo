using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text.Json;

namespace IdentityDemo.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        //1-recive request delegate and host env from constructor
        //2 create async InvokeAsync method and pass the httpContext context 
        //3 the use try catch block to catch ex and write new context
        //4 create new response object to send response we can use ProblemDetails obj optional
        //5 and write to context json camel case
        //6 add middleware to pipeline

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ProblemDetails
                {
                    Title = ex.Message,
                    Detail = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null,
                    Status = 500,
                };
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
