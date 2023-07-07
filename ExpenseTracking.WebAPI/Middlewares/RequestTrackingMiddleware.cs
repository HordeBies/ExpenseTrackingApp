using System.Diagnostics;

namespace ExpenseTracking.WebAPI.Middlewares
{
    public class RequestTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTrackingMiddleware> _logger;

        public RequestTrackingMiddleware(RequestDelegate next, ILogger<RequestTrackingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var request = context.Request;
                var response = context.Response;

                _logger.LogInformation(
                    "Request: {requestMethod} {requestPath} | " +
                    "Response: {responseStatusCode} | " +
                    "Duration: {responseDuration} ms"
                    , request.Method, request.Path, response.StatusCode, stopwatch.Elapsed.TotalMilliseconds);
            }
        }

    }

    public static class RequestTrackingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTrackingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTrackingMiddleware>();
        }
    }
}
