using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCommerce.API.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");
                if(ex.InnerException is not null)
                {
                    logger.LogError($"{ex.InnerException.GetType().ToString()} : {ex.InnerException.Message}");
                }
                //Internal server error
                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new { Message = ex.GetType().ToString(), Type = ex.Message});
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}


/*
 * 
 * 
 * 
 * 
 *
 * 
 * 
 */