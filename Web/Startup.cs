using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repo;
using Infrastructure.Repo.Base;
using Microsoft.AspNetCore.Builder;
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

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(IAdminRepo), typeof(AdminRepo));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //Static FIles//
            app.UseStaticFiles();
            //
            app.UseAuthentication();
            //
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                    endpoints.MapControllerRoute(
                     name:   "defualtRoute",
                      pattern:  "{controller=Home}/{action=Index}/{id?}"
                        ); 
            });
        }
    }
}
