using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddLogging(x => x.AddConsole());
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                var url = context.Request.Query["r"];
                if (url.Any())
                {
                    if (url[0] == "")
                    {
                        url = "/";
                    }
                    context.Response.Redirect(url);
                }
                var name = Configuration.GetSection("Author").GetSection("Name").Value;
                context.Response.Headers.Add("X-Checked-By", name);
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapFallbackToController("/signup", "SignUp", "Home");
                endpoints.MapFallbackToController("/signin", "SignIn", "Home");
                endpoints.MapFallbackToController("/todos", "Todos", "Home");
                endpoints.MapFallbackToController("/hello.json", "HelloJson", "Home");
                endpoints.MapFallbackToController("/hello", "Hello", "Home");
                endpoints.MapFallbackToController("/", "Index", "Home");
            });
        }
    }
}
