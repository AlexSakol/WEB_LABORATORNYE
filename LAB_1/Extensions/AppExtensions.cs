using WEB.Middleware;

namespace WEB.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
            => app.UseMiddleware<LogMiddleware>();
    }
}
