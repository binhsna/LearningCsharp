using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hello_asp
{
    public class Program
    {
        /*
            Host (IHost) object:
                - Dependency Injection (ID): IServiceProvider (ServiceCollection)
                - Logging (ILogging)
                - Configuration
                - IHostedService => StartAsync: Run HTTP Server (Kestrel Http) 

            1) Tạo IHostBuilder 
            2) Cấu hình, đăng ký các dịch vụ (Gọi ConfigureWebHostDefaults)
            3) IHostBuilder.Build() => Host (IHost)
            4) Host.Run();       

            Request => pipeline (Middleware)

        */
        // public static void Main(string[] args)
        // {
        //     Console.WriteLine("Start App");
        //     IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //     // Cấu hình mặc định cho HOST tạo ra
        //     builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
        //     {
        //         // Tùy biến thêm về Host
        //         // webBuilder.
        //         webBuilder.UseWebRoot("public");
        //         webBuilder.UseStartup<MyStartup>();


        //     });

        //     IHost host = builder.Build();
        //     host.Run();
        // }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<MyStartup>();
                });
    }
}
