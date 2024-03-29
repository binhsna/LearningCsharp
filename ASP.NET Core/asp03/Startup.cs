using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
// dotnet add package Newtonsoft.Json
namespace asp03
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                     HtmlHelper.DefaultMenuTopItems(), context.Request
                    );

                    var html = HtmlHelper.HtmlDocument("Trang chu", menu + HtmlHelper.HtmlTrangchu());

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/RequestInfo", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                     HtmlHelper.DefaultMenuTopItems(), context.Request
                    );
                    var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div", "container");
                    var html = HtmlHelper.HtmlDocument("Thong tin Request", menu + info);

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/Encoding", async context =>
                {
                    string menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                    string htmlec = RequestProcess.Encoding(context.Request).HtmlTag("div", "container");
                    string html = HtmlHelper.HtmlDocument("Encoding", (menu + htmlec));
                    await context.Response.WriteAsync(html);
                });

                // /Cookies/write
                // /Cookies/read
                endpoints.MapGet("/Cookies/{*action}", async (context) =>
                {
                    var menu = HtmlHelper.MenuTop(
                      HtmlHelper.DefaultMenuTopItems(), context.Request
                     );

                    var action = context.GetRouteValue("action") ?? "read";

                    string message = "";
                    if (action.ToString() == "write")
                    {
                        // tên - giá trị - thời gian hiệu lực
                        var option = new CookieOptions()
                        {
                            Path = "/",
                            Expires = DateTime.Now.AddDays(1)
                        };

                        context.Response.Cookies.Append("masanpham", "3141355313", option);
                        message = "Cookie duoc ghi";
                    }
                    else
                    {
                        // Lấy danh sách các Header và giá trị  của nó, dùng Linq để lấy
                        var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                        message = string.Join("", listcokie).HtmlTag("ul");
                    }
                    var huongdan = "<a class=\"btn btn-danger\" href=\"/Cookies/read\">Doc Cookie</a><a class=\"btn btn-success\" href=\"/Cookies/write\">Ghi Cookie</a>";
                    huongdan = huongdan.HtmlTag("div", "container mt-4");
                    message = message.HtmlTag("div", "alert alert-danger");

                    var html = HtmlHelper.HtmlDocument("Cookie: " + action, menu + huongdan + message);

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/Json", async context =>
                {
                    var p = new
                    {
                        TenSp = "Dong ho Abc",
                        Gia = 5000000,
                        NgaySX = new DateTime(2000, 12, 31)
                    };
                    context.Response.ContentType = "application/json";
                    var json = JsonConvert.SerializeObject(p);
                    await context.Response.WriteAsync(json);
                });

                endpoints.MapMethods("/Form", new string[] { "POST", "GET" }, async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                     HtmlHelper.DefaultMenuTopItems(), context.Request
                    );

                    var formhtml = RequestProcess.ProcessForm(context.Request);

                    var html = HtmlHelper.HtmlDocument("Test submit form html", menu + formhtml);

                    await context.Response.WriteAsync(html);
                });

            });
        }
    }
}
