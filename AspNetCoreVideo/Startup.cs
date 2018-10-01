using System;
using System.IO;
using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreVideo
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //            services.AddSingleton<IMessageService, HardcodedMessageService>();
            services.AddMvc();
            services.AddScoped<IVideoData, MockVideoData>();
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

//            app.UseStaticFiles();
//            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async context =>
            {
//                throw new Exception("Fake Exception!");
//                var message = Configuration.GetConnectionString("Message");
//                await context.Response.WriteAsync("Message: " + message);
                await context.Response.WriteAsync("Message: " + msg.GetMessage());
            });
        }
    }
}