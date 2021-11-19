using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Core.Interfaces.Discounts;
using Infrastructure.Data;
using Infrastructure.Repo;
using Infrastructure.Repo.Base;
using Infrastructure.Repo.Discounts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration Configuration) ///To go to Configuraion file appsetting.json
        {
            this.Configuration = Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //we deal wit contr and views (1)
            services.AddControllersWithViews();
            ///
            services.AddDbContext<DataContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EcoMeraceDb")));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DataContext>();
            ///

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;
            });

            services.AddAutoMapper(typeof(Startup));


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(IAdminRepo), typeof(AdminRepo));
            services.AddScoped(typeof(IProductRepo), typeof(ProductRepo));
            services.AddScoped(typeof(ICategoryRepo), typeof(CategoryRepo));
            services.AddScoped(typeof(ICustomerRepo), typeof(CustomerRepo));
            services.AddScoped(typeof(IRoleRepo), typeof(RoleRepo));
            services.AddScoped(typeof(IDiscount), typeof(DiscountRepo));

            //Static FIles//
            services.AddCors(c => {
                c.AddPolicy("policyName", p => {
                    p.AllowAnyOrigin().AllowAnyMethod();
                });
            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("policyName");


            //Static FIles//
            app.UseStaticFiles();
            //
            app.UseRouting();
        
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "areaRoute",
                   pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}"

                 );

                endpoints.MapControllerRoute(
                     name:   "defualtRoute",
                      pattern:  "{controller=Home}/{action=Index}/{id?}"
                        ); 
            });
        }
    }
}
