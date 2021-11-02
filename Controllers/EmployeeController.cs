using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Services;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Controllers{
    public class EmployeeController : Controller{
        public async Task<IActionResult> Index(){
            var svc = new EmployeeService();
            var model = await svc.GetAllEmployeesAsync();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public async Task<IActionResult> Create(EmployeeCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = new EmployeeService();
            if (await svc.CreateEmployeeAsync(model)){
                TempData["SaveResult"] = "Employee has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("EmployeeCreateFailed", "Something went wrong while attempting to create the Employee, please try again.");
            return View(model);
        }

        public IActionResult Details(Guid id){
            var svc = new EmployeeService();
            var model = svc.GetEmployeeByID(id);
            return View(model);
        }

        public async Task<IActionResult> IndexByBirthday(DateTime birthday){
            var svc = new EmployeeService();
            var model = await svc.GetEmployeesByBirthdayAsync(birthday);
            return View(model);
        }

        public async Task<IActionResult> IndexByStatus(bool status){
            var svc = new EmployeeService();
            var model = await svc.GetEmployeesByStatusAsync(status);
            return View(model);
        }

        public async Task<IActionResult> IndexByPermissionLevel(int level){
            var svc = new EmployeeService();
            var model = await svc.GetEmployeesByPermissionLevelAsync(level);
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var svc = new EmployeeService();
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
        public async Task<IActionResult> Edit(Guid id, EmployeeEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.EmployeeID != id){
                ModelState.AddModelError("EmployeeIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new EmployeeService();
            if (await svc.UpdateEmployeeAsync(model)){
                TempData["SaveResult"] = "Employee information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("EmployeeEditFailed", "Something went wrong while attempting to update the Employee information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var svc = new EmployeeService();
            var model = svc.GetEmployeeByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteEmployee(Guid id){
            var svc = new EmployeeService();
            await svc.DeleteEmployeeAsync(id);
            TempData["SaveResult"] = "Employee has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}