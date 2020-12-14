<<<<<<< HEAD
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
>>>>>>> origin/Layout,Main-page
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Ain_Shams_Hospital
=======
namespace Project
>>>>>>> origin/Layout,Main-page
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
<<<<<<< HEAD

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("HospitalConnectionString"));
            });
            services.AddControllersWithViews();
        }


=======
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

>>>>>>> origin/Layout,Main-page
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
<<<<<<< HEAD
                app.UseExceptionHandler("/Registration/Error");
=======
                app.UseExceptionHandler("/Home/Error");
>>>>>>> origin/Layout,Main-page
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
<<<<<<< HEAD
                    pattern: "{controller=Registration}/{action=Index}/{id?}");
=======
                    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> origin/Layout,Main-page
            });
        }
    }
}
