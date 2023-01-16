using DemoWork.DataLayer.DataLayer;
using DemoWork.Entities;
using DemoWork.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWork.Administration
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DemoWorkContext>();
            services.AddRazorPages();
            //services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<DemoWorkContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseRouting();

            //app.UsePathBase("/user/index");                     // by using path
            app.UsePathBase("/Administration/user/index");        // by using name

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                #region Administration

                endpoints.MapAreaControllerRoute(
                   name: "AdministrationHome",
                   areaName: "Administration",
                   pattern: "/{controller=Customer}/{action=Index}"
               );

                endpoints.MapAreaControllerRoute(
                  name: "AdministrationRegister",
                  areaName: "Administration/Account",
                  pattern: "/{controller=Account}/{action=Register}"
              );

                endpoints.MapAreaControllerRoute(
                name: "AdministrationLogin",
                areaName: "Administration/Account",
                pattern: "/{controller=Account}/{action=Login}"
            );

                #endregion



            });
        }
    }
}
