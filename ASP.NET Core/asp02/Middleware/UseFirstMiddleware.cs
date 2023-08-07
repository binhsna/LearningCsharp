using Microsoft.AspNetCore.Builder;

namespace asp02.Middleware
{
    public static class UseFirstMiddlewareMethod
    {
        public static void UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void UseSecondtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}