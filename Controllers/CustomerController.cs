using System;
using Microsoft.AspNetCore.Mvc;
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
            string[] fmlNames = detail.CustomerName.Split(' ');
            string[] address = detail.CustomerAddress.Split('\r');
            string[] cityState = address[3].Split(',');
            string zip = address[3].Split(' ')[1];
            var model = new CustomerEdit{
                CustomerID = detail.CustomerID,
                CustomerFirstName = fmlNames[0],
                CustomerMiddleName = fmlNames[1],
                CustomerLastName = fmlNames[2],
                CustomerEmail = detail.CustomerEmail,
                CustomerPhone = detail.CustomerPhone,
                CustomerAddressLine1 = address[0],
                CustomerAddressLine2 = address[1],
                CustomerAddressLine3 = address[2],
                CustomerAddressCity = cityState[0],
                CustomerAddressStateOrProvince = cityState[1],
                CustomerAddressPostalCode = zip,
                CustomerAddressCountry = address[4]
            };
            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(Guid id, CustomerEdit model){
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerID != id){
                ModelState.AddModelError("CustomerIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = CreateCustomerService();
            if (svc.UpdateCustomer(model)){
                TempData["SaveResult"] = "Customer information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CustomerEditFailed", "Something went wrong while attempting to update the Customer information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var svc = CreateCustomerService();
            var model = svc.GetCustomerByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteCustomer(Guid id){
            var svc = CreateCustomerService();
            svc.DeleteCustomer(id);
            TempData["SaveResult"] = "Customer has been successfully deleted!";
            return Redirect(nameof(Index));
        }

        private CustomerService CreateCustomerService(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            return new CustomerService(userID);
        }
    }
}