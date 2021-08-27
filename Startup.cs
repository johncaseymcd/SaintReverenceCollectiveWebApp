using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaintReverenceMVC.Data;


namespace SaintReverenceMVC
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
            services.AddServerSideBlazor();
            services.AddDbContext<src_backendContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SaintReverenceDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapBlazorHub();
                endpoints.MapControllerRoute(
                    name: "CollectionsEndingSoon",
                    pattern: "{controller=Collection}/{action=IndexByEndDate}/{twoWeeks}"
                );
                endpoints.MapControllerRoute(
                    name: "CollectionDefault",
                    pattern: "{controller=Collection}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "Birthday",
                    pattern: "{controller}/{action=IndexByBirthday}/{birthday}"
                );
                endpoints.MapControllerRoute(
                    name: "CustomerDefault",
                    pattern: "{controller=Customer}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "ActiveStatus",
                    pattern: "{controller}/{action=IndexByStatus}/{status}"
                );
                endpoints.MapControllerRoute(
                    name: "EmployeesByPermissionLevel",
                    pattern: "{controller=Employee}/{action=IndexByPermissionLevel/{level}"
                );
                endpoints.MapControllerRoute(
                    name: "EmployeeDefault",
                    pattern: "{controller=Employee}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoicesByPastDue",
                    pattern: "{controller=Invoice}/{action=IndexByPastDue}/{currentDate}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoicesDueSoon",
                    pattern: "{controller=Invoice}/{action=IndexByDueSoon}/{twoWeeks}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoiceDefault",
                    pattern: "{controller=Invoice}/{action}/{id?}"
                );
            });
        }
    }
}
