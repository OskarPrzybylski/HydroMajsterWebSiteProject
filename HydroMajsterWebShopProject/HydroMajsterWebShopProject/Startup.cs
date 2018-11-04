using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models;
using HydroMajsterWebShopProject.Models.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HydroMajsterWebShopProject.Models.Services;

namespace HydroMajsterWebShopProject
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
            services.AddMvc();
            var connectionString =
                "User ID=xlolvddatltdxu;Password=adfa021f1d55164d3547d27a509fb6513f892fde7e8009bbd45301ad39e3f91c;Host=ec2-54-247-79-32.eu-west-1.compute.amazonaws.com;Port=5432;Database=d2aliisaq2mkp4;Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;";
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options => 
            options.UseNpgsql(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<CategoriesIntoSelectListService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
