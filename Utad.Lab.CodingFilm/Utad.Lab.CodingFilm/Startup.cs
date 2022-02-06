using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Data;
using Utad.Lab.CodingFilm.Models;
using Utad.Lab.WebApp.Data;

namespace Utad.Lab.CodingFilm
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            // Aqui adicionamos Utilizador como defaultIdentity pq queremos passar para
            // as pages do Identity os parametros que adicionamos novos
            services.AddDefaultIdentity<Utilizador>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            /*.Net Core auto-registered controllers with views and the razor pages, but if it is not 
             * registered, in your web application, in any case,  please register it like this.*/
            services.AddRazorPages();
            services.AddControllersWithViews();

            /*Because Area is the MVC concept, for enabling areas in .Net Core, we have to register MVC . 
             * And EnableEndpointRouting is set to false in the startup.cs file.*/
            services.AddMvc(options => options.EnableEndpointRouting = false);


            services.AddAuthentication()
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //  Cria os roles
            SeedRoles.Seed(roleManager);

            app.UseEndpoints(endpoints =>
            {
                //  Definição de Routes de áreas
                endpoints.MapAreaControllerRoute(
                  name: "AdminArea",
                  areaName: "Admin",
                  pattern: "Admin/{controller=Manage}/{action=Index}");

                // Definição da Route padrão
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

        }
    }
}
