using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class EmployeeController : Controller{
        public IActionResult Index(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            var svc = new EmployeeService(userID);
            var model = svc.GetAllEmployees();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(EmployeeCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = CreateEmployeeService();
            if (svc.CreateEmployee(model)){
                TempData["SaveResult"] = "Employee has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("EmployeeCreateFailed", "Something went wrong while attempting to create the Employee, please try again.");
            return View(model);
        }

        public IActionResult Details(Guid id){
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeByID(id);
            return View(model);
        }

        public IActionResult IndexByBirthday(DateTime birthday){
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeesByBirthday(birthday);
            return View(model);
        }

        public IActionResult IndexByStatus(bool status){
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeesByStatus(status);
            return View(model);
        }

        public IActionResult IndexByPermissionLevel(int level){
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeesByPermissionLevel(level);
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var svc = CreateEmployeeService();
            var detail = svc.GetEmployeeByID(id);
            string[] fmlNames = detail.EmployeeName.Split(' ');
            string[] address = detail.EmployeeAddress.Split('\r');
            string[] cityState = address[3].Split(',');
            string zip = address[3].Split(' ')[1];
            var model = new EmployeeEdit{
                EmployeeID = detail.EmployeeID,
                EmployeeFirstName = fmlNames[0],
                EmployeeMiddleName = fmlNames[1],
                EmployeeLastName = fmlNames[2],
                EmployeeEmail = detail.EmployeeEmail,
                EmployeePhone = detail.EmployeePhone,
                EmployeeAddressLine1 = address[0],
                EmployeeAddressLine2 = address[1],
                EmployeeAddressLine3 = address[2],
                EmployeeAddressCity = cityState[0],
                EmployeeAddressStateOrProvince = cityState[1],
                EmployeeAddressPostalCode = zip,
                EmployeeAddressCountry = address[4],
                EmployeeSalaryPerYear = detail.EmployeeSalaryPerYear,
                EmployeeHoursPerWeek = detail.EmployeeHoursPerWeek,
                EmployeeIsActive = detail.EmployeeIsActive,
                EmployeePermissionLevel = detail.EmployeePermissionLevel
            };
            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(Guid id, EmployeeEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.EmployeeID != id){
                ModelState.AddModelError("EmployeeIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = CreateEmployeeService();
            if (svc.UpdateEmployee(model)){
                TempData["SaveResult"] = "Employee information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("EmployeeEditFailed", "Something went wrong while attempting to update the Employee information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteEmployee(Guid id){
            var svc = CreateEmployeeService();
            svc.DeleteEmployee(id);
            TempData["SaveResult"] = "Employee has been successfully deleted!";
            return Redirect(nameof(Index));
        }

        private EmployeeService CreateEmployeeService(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            return new EmployeeService(userID);
        }
    }
}