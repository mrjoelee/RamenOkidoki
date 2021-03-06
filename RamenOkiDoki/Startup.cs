using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DbContext;
using Data.Models;
using Data.Models.FoodMenus;
using Data.Repositories;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.StaticFiles;


//using Microsoft.EntityFrameworkCore;

namespace RamenOkiDoki
{
    public class Startup
    {
        public IWebHostEnvironment Env { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Globals.GetFoodItemsAndCategories();
            Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.


        //this is the usage of Dependency Injection
        //IServiceCollection services - multiple services
        public void ConfigureServices(IServiceCollection services)
        {
         

            services.AddTransient<DatabaseRepository>();

            //Add Razor Pages, which is the typical way to use Blazer. 
            services.AddRazorPages().WithRazorPagesRoot("/Views");

            //Add Blazor. Note that no etra packages are needed. 
            services.AddServerSideBlazor();

            if (Env.IsDevelopment())
            {
                services.AddControllersWithViews().AddRazorRuntimeCompilation();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //MiddleWares - influence how the whole response for the request from browser will be.
            app.UseHttpsRedirection();

            //uses the wwwroot files
            app.UseStaticFiles();

            //process through which the application matches the requested URL path and executes the related Controller and Action.
            app.UseRouting();

            app.UseAuthorization();

            //endpoints can be MVC, Razor Pages and SignalR
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();
                
            });
        }
    }
}
