
using System.Diagnostics;

namespace Resturants.Api.Middlewares
{
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWatch = Stopwatch.StartNew();
            await next.Invoke(context);
            if (stopWatch.ElapsedMilliseconds / 1000 > 4)
            {
                logger.LogInformation($"Request [{context.Request.Method}] at [{context.Request.Path}] took [{stopWatch.ElapsedMilliseconds}] ms")
            }
            
        }
    }
}
