using System.Diagnostics;

namespace Shopper.Api.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        var watch = new Stopwatch();
        watch.Start();
        await next(context);
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds /1000;
        if(elapsedMs  > 4)
        logger.LogInformation("Request [{method}] at {path} executed in {elapsedMs} s"
            ,context.Request.Method,context.Request.Path,elapsedMs);


    }
}