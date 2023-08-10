using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace razor01.basic
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Đăng ký các dịch vụ liên quan đến Razor đã được đăng ký vào hệ thống
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                // Đổi tên thư mục mặc định là Pages
                options.RootDirectory = "/Pages";
                options.Conventions.AddPageRoute("/FirstPage", "trang-dau-tien");
            });

            services.Configure<RouteOptions>(routeOptions =>
            {
                // Chuyển hết link về chữ in thường
                routeOptions.LowercaseUrls = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                // FirstPage.cshtml -> URL=/FirstPage   /SecondPage  /ThirdPage
                // Dichvu/Dichvu1
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
/*
    Razor page(.cshtml) = html + c#
    Engine Razor -> Biên dịch cshtml -> Response
    - @page "url"
    - @bien, @(biểu thức), @phương thức
    -
    @{
        code c#
        <HTML><HTML> -> Nhúng html ở trong code c#
    }

    Rewrite URL -> Viết lại URL -> /trang-dau-tien

    Tag Helper -> Giúp phát sinh ra nội dung HTML
    @addTagHelper -> Nạp các helper vào các Razor Page
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

    ViewData["keyData"]

*/