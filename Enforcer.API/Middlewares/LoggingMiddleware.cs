namespace EnforcerAPI.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request: {context.Request.Method} - {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");

            await next.Invoke(context);

            switch (context.Response.StatusCode)
            {
                case 400:
                    _logger.LogWarning($"{DateTime.UtcNow} UTC - Incorrect request: {context.Request.Method} - {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
                    break;
                case 404:
                    _logger.LogWarning($"{DateTime.UtcNow} UTC - Resource not found: {context.Request.Method} - {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
                    break;
                case 500:
                    _logger.LogWarning($"{DateTime.UtcNow} UTC - Connection has failed: {context.Request.Method} - {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
                    break;
                default:
                    _logger.LogInformation($"{DateTime.UtcNow} UTC - Response status code: {context.Response.StatusCode}");
                    break;
            }
        }
    }
}
