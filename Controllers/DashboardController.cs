using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.DashboardModels;
using SaintReverenceMVC.Services;
using System.Security.Claims;
using System;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Controllers{
    public class DashboardController : Controller{
        ICollectionService collectionService = new CollectionService();
        ICustomerService customerService = new CustomerService();
        IEmployeeService employeeService = new EmployeeService();
        IInvoiceService invoiceService = new InvoiceService();
        IOrderService orderService = new OrderService();
        IProductService productService = new ProductService();


        // GET: Dashboard
        public async Task<IActionResult> Index(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            DashboardService service = new(collectionService, customerService, employeeService, invoiceService, orderService, productService);
            DashboardViewModel model = new();
            
            model.AllCollections = await service.DisplayAllCollectionsAsync();
            model.TopCustomers = await service.DisplayTopCustomersAsync();
            model.NewEmployees = await service.DisplayNewEmployeesAsync();
            model.UnpaidInvoices = await service.DisplayUnpaidInvoicesAsync();
            model.UnfulfilledOrders = await service.DisplayUnfulfilledOrdersAsync();
            model.LowInventoryProducts = await service.DisplayLowInventoryProductsAsync();
            return View(model);
        }


    }
}