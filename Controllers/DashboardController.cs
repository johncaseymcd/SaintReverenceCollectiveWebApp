using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.DashboardModels;
using SaintReverenceMVC.Services;
using System.Security.Claims;
using System;
using System.Linq;

namespace SaintReverenceMVC.Controllers{
    public class DashboardController : Controller{
        // Dependency Injection of services goes here

        // GET: Dashboard
        public ActionResult Index(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            CollectionService collectionSvc = new();
            CustomerService customerSvc = new();
            EmployeeService employeeSvc = new(userID);
            InvoiceService invoiceSvc = new();
            OrderService orderSvc = new(userID);
            ProductService productSvc = new();

            var model = new DashboardViewModel();
            model.AllCollections = collectionSvc.GetAllCollections();
            model.TopCustomers = customerSvc.GetVIPCustomers().Take(10);
            model.NewEmployees = employeeSvc.GetAllEmployees().OrderByDescending(ehd => ehd.EmployeeHireDate);
            model.UnpaidInvoices = invoiceSvc.GetInvoicesByPaidStatus(false);
            model.UnfulfilledOrders = orderSvc.GetAllOrders().Where(os => os.OrderStatus == 1 || os.OrderStatus == 2).OrderBy(od => od.OrderDate);
            model.LowInventoryProducts = productSvc.GetAllProducts().Where(pc => pc.ProductInventoryCount <= (pc.ProductMaxInventoryCount * 0.2)).OrderBy(pc => pc.ProductInventoryCount);

            return View(model);
        }


    }
}