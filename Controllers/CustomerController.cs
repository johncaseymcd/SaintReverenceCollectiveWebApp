using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class CustomerController : Controller{
        public IActionResult Index(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            var svc = new CustomerService(userID);
            var model = svc.GetAllCustomers();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(CustomerCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = CreateCustomerService();
            if(svc.CreateCustomer(model)){
                TempData["SaveResult"] = "Customer has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CustomerCreateFailed", "Something went wrong while attempting to create the Customer, please try again.");
            return View(model);
        }

        public IActionResult Details(Guid userID){
            var svc = CreateCustomerService();
            var model = svc.GetCustomerByID(userID);
            return View(model);
        }        

        public IActionResult IndexByBirthday(DateTime birthday){
            var svc = CreateCustomerService();
            var model = svc.GetCustomersByBirthday(birthday);
            return View(model);
        }

        public IActionResult IndexByVIP(){
            var svc = CreateCustomerService();
            var model = svc.GetVIPCustomers();
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var svc = CreateCustomerService();
            var detail = svc.GetCustomerByID(id);
            // create model and split name string from details
        }

        private CustomerService CreateCustomerService(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            return new CustomerService(userID);
        }
    }
}