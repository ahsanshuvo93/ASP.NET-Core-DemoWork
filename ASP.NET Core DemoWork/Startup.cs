using DemoWork.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_DemoWork
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
           

            //app.UsePathBase("/user/index");       // by using path
            app.UsePathBase("/WebsiteHome");        // by using name


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                #region WebApplication

                endpoints.MapAreaControllerRoute(
                   name: "WebsiteHome",
                   areaName: "WebApplication",
                   pattern: "/{controller=User}/{action=Index}"
               );

                #endregion



            });

        }
    }
}
