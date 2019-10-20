using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using EF_MSSQL_DataStore;
using EF_MSSQL_Identity_DataStore;
using EasyMealCore.DomainServices;
using EasyMealOrderGUI.Models;
using EasyMealCore.DomainModel;

namespace EasyMealOrderGUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
             Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:EasyMeal:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:EasyMealIdentity:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddTransient<IMealRepository, EFMealRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(name: "Error", template: "Error",
                    defaults: new { controller = "Error", action = "Error" });

                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Meal", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Meal", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Meal", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Meal", action = "List", productPage = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            SeedDataIdentity.EnsurePopulated(userManager).Wait();

            SeedData.EnsurePopulated(app.ApplicationServices.GetRequiredService<ApplicationDbContext>());

            //Task callTask = Task.Run(() => SeedDataIdentity.EnsurePopulated(userManager));
            //callTask.Wait();

            //var task = SeedDataIdentity.EnsurePopulated(userManager);
        }
    }
}
