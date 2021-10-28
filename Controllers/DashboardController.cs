using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Models.ProductModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class DashboardController : Controller{
        // Dependency Injection of services goes here
        // Add user ID

        // GET: Dashboard
        public ActionResult Index(){
            var collectionSvc = new CollectionService();
            var customerSvc = new CustomerService();
            var employeeSvc = new EmployeeService();
            var invoiceSvc = new InvoiceService();
            var orderSvc = new OrderService();
            var productSvc = new ProductService();
        }
    }
}