using System;
using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.PackageModels;
using SaintReverenceMVC.Services;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Controllers{
    public class PackageController : Controller{
        public async Task<IActionResult> Index(){
            var svc = new PackageService();
            var model = await svc.GetAllPackagesAsync();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public async Task<IActionResult> Create(PackageCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = new PackageService();
            if (await svc.CreatePackageAsync(model)){
                TempData["SaveResult"] = "Package has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("PackageCreateFailed", "Something went wrong while attempting to create the Package, please try again.");
            return View(model);
        }

        public IActionResult Details(int id){
            var svc = new PackageService();
            var model = svc.GetPackageByID(id);
            return View(model);
        } 

        // GET: Edit
        public IActionResult Edit(int id){
            var svc = new PackageService();
            var detail = svc.GetPackageByID(id);
            var model = new PackageEdit{
                PackageID = detail.PackageID,
                PackageCostToShip = detail.PackageCostToShip
            };
            return View(model);
        }

        // POST: Edit
        public async Task<IActionResult> Edit(int id, PackageEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.PackageID != id){
                ModelState.AddModelError("PackageIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new PackageService();
            if (await svc.UpdatePackageAsync(model)){
                TempData["SaveResult"] = "Package information was successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("PackageEditFailed", "Something went wrong while attempting to update the package information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(int id){
            var svc = new PackageService();
            var model = svc.GetPackageByID(id);
            return View(model);            
        }

        // POST: Delete
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePackage(int id){
            var svc = new PackageService();
            await svc.DeletePackageAsync(id);
            TempData["SaveResult"] = "Package has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}