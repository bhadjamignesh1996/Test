namespace TheChat.Extensions
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }

    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"].ToString().ToLower();
            //Console.WriteLine($"Request path: {context.Request.Path}");
            if ( userAgent.Contains("insomnia") || userAgent.Contains("curl"))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Requests from this tool are not allowed.");
                return;
            }
            await _next(context);
            //Console.WriteLine($"Response status code: {context.Response.StatusCode}");
        }
    }
}
