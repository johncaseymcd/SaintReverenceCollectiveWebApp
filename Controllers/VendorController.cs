using System;
using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.VendorModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class VendorController : Controller{
        public IActionResult Index(){
            var svc = new VendorService();
            var model = svc.GetAllVendors();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(VendorCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = new VendorService();
            if (svc.CreateVendor(model)){
                TempData["SaveResult"] = "Vendor has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("VendorCreateFailed", "Something went wrong while attempting to add the Vendor, please try again.");
            return View(model);
        }

        public IActionResult Details(int id){
            var svc = new VendorService();
            var model = svc.GetVendorByID(id);
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(int id){
            var svc = new VendorService();
            var detail = svc.GetVendorByID(id);
            string[] address = detail.VendorAddress.Split('\r');
            string[] cityState = address[3].Split(',');
            string zip = address[3].Split(' ')[1];
            var model = new VendorEdit{
                VendorID = detail.VendorID,
                VendorName = detail.VendorName,
                VendorEmail = detail.VendorEmail,
                VendorWebsite = detail.VendorWebsite,
                VendorPhone = detail.VendorPhone,
                VendorAddressLine1 = address[0],
                VendorAddressLine2 = address[1],
                VendorAddressLine3 = address[2],
                VendorAddressCity = cityState[0],
                VendorAddressStateOrProvince = cityState[1],
                VendorAddressPostalCode = zip,
                VendorAddressCountry = address[4]
            };
            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(int id, VendorEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.VendorID != id){
                ModelState.AddModelError("VendorIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new VendorService();
            if (svc.UpdateVendor(model)){
                TempData["SaveResult"] = "Vendor information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("VendorEditFailed", "Something went wrong while attempting to update the vendor information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(int id){
            var svc = new VendorService();
            var model = svc.GetVendorByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteVendor(int id){
            var svc = new VendorService();
            svc.DeleteVendor(id);
            TempData["SaveResult"] = "Vendor has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}