using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using Shopper.Domain.Exceptions;

namespace Shopper.Api.Middlewares
{
    public class ErrorHandlingMiddleWare(ILogger<ErrorHandlingMiddleWare> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
                await next(context);
            }
            catch (NotFoundException notFound)
            {
                // context.Response.ContentType = "application/json";
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFound.Message);
                logger.LogWarning("{Message}", notFound.Message);

            }
            
            catch (AuthenticationException authenticationException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(authenticationException.Message);
                logger.LogWarning("{Message}", authenticationException.Message);

            }

            catch (Exception ex)
            {
                // context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                //var response = new ErrorResponse
                //{
                //    Message = "Internal Server Error"
                //};

                // var result = JsonSerializer.Serialize("response");
                await context.Response.WriteAsync("Something went wrong");
                logger.LogError("{Error} - {Message}" ,ex, ex.Message);
            }




        }
    }
}
