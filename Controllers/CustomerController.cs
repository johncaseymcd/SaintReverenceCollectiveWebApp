using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Services;
using Microsoft.AspNetCore.Authorization;
using SaintReverenceMVC.Services.ServiceContracts;

namespace SaintReverenceMVC.Controllers{
    [Authorize]
    public class CustomerController : Controller{
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service){
            _service = service;
        }
        public IActionResult Index(){
            var model = _service.GetAllCustomers();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(CustomerCreate model){
            if (!ModelState.IsValid) return View(model);

            if(_service.CreateCustomer(model)){
                TempData["SaveResult"] = "Customer has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CustomerCreateFailed", "Something went wrong while attempting to create the Customer, please try again.");
            return View(model);
        }

        public IActionResult Details(Guid userID){
            var model = _service.GetCustomerByID(userID);
            return View(model);
        }        

        public IActionResult IndexByBirthday(DateTime birthday){
            var model = _service.GetCustomersByBirthday(birthday);
            return View(model);
        }

        public IActionResult IndexByVIP(){
            var model = _service.GetVIPCustomers();
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var detail = _service.GetCustomerByID(id);
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

            if (_service.UpdateCustomer(model)){
                TempData["SaveResult"] = "Customer information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CustomerEditFailed", "Something went wrong while attempting to update the Customer information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var model = _service.GetCustomerByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteCustomer(Guid id){
            _service.DeleteCustomer(id);
            TempData["SaveResult"] = "Customer has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}