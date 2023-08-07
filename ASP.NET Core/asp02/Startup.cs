using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp02.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp02
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Do kế thừa từ interface IMiddleware
            services.AddSingleton<SecondMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); // StaticFileMiddleware
            // app.UseMiddleware<FirstMiddleware>();
            app.UseFirstMiddleware(); // Đưa vào pipeline FirstMiddleware
            app.UseSecondtMiddleware(); // Đưa vào pipeline SecondMiddleware

            app.UseRouting(); // EndpointRoutingMiddleware

            // Tạo Endpoint (Terminal Middleware)
            app.UseEndpoints(endpoint =>
            {
                // E1
                endpoint.MapGet("/about.html", async (context) =>
                {
                    await context.Response.WriteAsync("Trang gioi thieu");
                });
                // E2
                endpoint.MapGet("/sanpham.html", async (context) =>
                {
                    await context.Response.WriteAsync("Trang san pham");
                });
            });

            // Rẽ nhánh trong pipeline
            app.Map("/admin", app1 =>
            {
                // Tạo Middleware của nhánh

                app1.UseRouting(); // EndpointRoutingMiddleware

                // Tạo Endpoint (Terminal Middleware)
                app1.UseEndpoints(endpoint =>
                {
                    // Brand E1
                    endpoint.MapGet("/user", async (context) =>
                    {
                        await context.Response.WriteAsync("Trang quan ly User");
                    });
                    // Brand E2
                    endpoint.MapGet("/product", async (context) =>
                    {
                        await context.Response.WriteAsync("Trang quan ly san pham");
                    });
                });

                // Terminal Middleware M2
                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Trang Admin");
                });

            });

            // Terminal Middleware M1
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Xin chao ASP. NET Core");
            });

        }
    }
}
/*
    HttpContext
    pipeline: - StaticFileMiddleware
                 - FirstMiddlewar 
                    - SecondtMiddleware 
                        - EndpointRoutingMiddleware (E1, E2)
                            - M1

*/