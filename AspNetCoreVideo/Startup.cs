using System.IO;
using AspNetCoreVideo.Data;
using AspNetCoreVideo.Entities;
using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreVideo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
//                .AddJsonFile("appsettings.json", optional: true);
            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options => options.UseSqlServer(conn));
            //            services.AddSingleton<IMessageService, HardcodedMessageService>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<VideoDbContext>();
            services.AddSpaStaticFiles();
            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddScoped<IVideoData, SqlVideoData>();
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
//            services.AddSingleton<IVideoData, MockVideoData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

//            app.UseStaticFiles();
//            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
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