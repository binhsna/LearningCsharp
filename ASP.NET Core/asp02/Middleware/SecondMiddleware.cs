
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace asp02.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /**
            Url: "/xxx.html"
                - Không gọi Middleware phía sau
                - Bạn không được truy cập
                - Header - SecondMiddleware: Bạn không được truy cập
            Url: != "/xxx.html"
                - Header - SecondMiddleware: Bạn được truy cập
                - Chuyển httpcontext cho Middleware phía sau

        */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");

                var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (datafromFirstMiddleware != null)
                {
                    await context.Response.WriteAsync((string)datafromFirstMiddleware);
                }
                await context.Response.WriteAsync("Ban khong duoc truy cap");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban duoc truy cap");

                var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (datafromFirstMiddleware != null)
                {
                    await context.Response.WriteAsync((string)datafromFirstMiddleware);
                }
                await next(context);
            }
        }
    }
}