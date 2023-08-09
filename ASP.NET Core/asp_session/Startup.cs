using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp_session
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDistributedMemoryCache();

            services.AddDistributedSqlServerCache((option) =>
            {
                option.ConnectionString = "Data Source=localhost,1433;Initial Catalog=webdb;User ID=sa;Password=123";
                option.SchemaName = "dbo";
                option.TableName = "Session";
            });

            services.AddSession((option) =>
            {
                option.Cookie.Name = "binhnc";
                option.IdleTimeout = new TimeSpan(0, 30, 0); // 30 phút
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession(); // SessionMiddleware - Cookie (ID Session)

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    int? count; // count
                    count = context.Session.GetInt32("count"); // Đọc Session
                    count ??= 0;

                    await context.Response.WriteAsync($"So lan truy cap readWriteSession cap la {count}\n");
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/readWriteSession", async context =>
               {
                   int? count; // count
                   count = context.Session.GetInt32("count"); // Đọc Session
                   count ??= 0;
                   count++;
                   // Lưu Session
                   context.Session.SetInt32("count", count.Value);
                   // context.Session.SetString() - json (Newtonsoft.Json)

                   await context.Response.WriteAsync($"So lan truy cap readWriteSession cap la {count}\n");
               });
            });
        }
    }
}
/*
dotnet sql-cache create "Data Source=localhost,1433;Initial Catalog=webdb;User ID=sa;Password=123" dbo Session
*/