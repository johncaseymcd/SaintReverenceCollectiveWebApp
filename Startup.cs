using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Services.ServiceContracts;
using SaintReverenceMVC.Services;


namespace SaintReverenceMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddServerSideBlazor();
            services.AddDbContext<src_backendContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SaintReverenceDb")));
        }

        public void ConfigureContainer(ContainerBuilder builder){
            builder.RegisterType<CollectionService>().As<ICollectionService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<PackageService>().As<IPackageService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<VendorService>().As<IVendorService>();
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
                    pattern: "{controller=Collection}/{action=IndexByEndDate}"
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
                    name: "VIP",
                    pattern: "{controller=Customer}/{action=IndexByVIP}"
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
                    pattern: "{controller=Employee}/{action=IndexByPermissionLevel}/{level}"
                );
                endpoints.MapControllerRoute(
                    name: "EmployeeDefault",
                    pattern: "{controller=Employee}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoicesByPastDue",
                    pattern: "{controller=Invoice}/{action=IndexByPastDue}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoicesDueSoon",
                    pattern: "{controller=Invoice}/{action=IndexByDueSoon}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoiceByVendor",
                    pattern: "{controller=Invoice}/{action=IndexByVendor}/{vendorID}"
                );
                endpoints.MapControllerRoute(
                    name: "InvoiceDefault",
                    pattern: "{controller=Invoice}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "OrdersByStatus",
                    pattern: "{controller=Order}/{action=IndexByOrderStatus}/{orderStatus}"
                );
                endpoints.MapControllerRoute(
                    name: "OrdersByDate",
                    pattern: "{controller=Order}/{action=IndexByOrderDate}/{orderDate}"
                );
                endpoints.MapControllerRoute(
                    name: "OrderDefault",
                    pattern: "{controller=Order}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "PackageDefault",
                    pattern: "{controller=Package}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "ProductsInStock",
                    pattern: "{controller=Product}/{action=IndexByInStock}"
                );
                endpoints.MapControllerRoute(
                    name: "ProductsByCatgeory",
                    pattern: "{controller=Product}/{action=IndexByCategory}/{categoryID}"
                );
                endpoints.MapControllerRoute(
                    name: "ProductsByCollection",
                    pattern: "{controller=Product}/{action=IndexByCollection}/{collectionID}"
                );
                endpoints.MapControllerRoute(
                    name: "AddProductToOrder",
                    pattern: "{controller=Product}/{action=AddProductToOrder}/{productID}/{orderID}"
                );
                endpoints.MapControllerRoute(
                    name: "ProductDefault",
                    pattern: "{controller=Product}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "VendorDefault",
                    pattern: "{controller=Vendor}/{action}/{id?}"
                );
            });
        }
    }
}
