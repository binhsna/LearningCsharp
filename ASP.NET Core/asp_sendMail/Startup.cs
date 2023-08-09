using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp_sendMail
{
    public class Startup
    {
        IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var mailSettings = _configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailSettings);
            //
            services.AddTransient<SendMailService>();

        }
        /*
        Mail Server - Smtp
        SmtpClient

        Server: Mail Transporter (CentOS / Qmail, SendMail)


        */

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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/TestSendMail", async context =>
                {
                    var message = await MailUtils.MailUtils.SendMail("binhsna@gmail.com", "binhsna@gmail.com", "TEST", "Xin chao binh boong");

                    await context.Response.WriteAsync(message);
                });

                endpoints.MapGet("/TestGmail", async context =>
               {
                   var message = await MailUtils.MailUtils.SendGmail("binhsna@gmail.com", "binhsna@gmail.com", "TEST", "Xin chao binh boong", "binhsna@gmail.com", "ykpyfwmwylhwxlli");

                   await context.Response.WriteAsync(message);
               });

                endpoints.MapGet("/TestSendMailService", async context =>
               {
                   var sendMailService = context.RequestServices.GetService<SendMailService>();

                   var mailContent = new MailContent();
                   mailContent.To = "binhsna@gmail.com";
                   mailContent.Subject = "KIEM TRA THU EMAIL";
                   mailContent.Body = "<h1>TEST</h1><i>Xin chao binh boong</i>";

                   var message = await sendMailService.SendMail(mailContent);

                   await context.Response.WriteAsync(message);
               });
            });
        }
    }
}
