using System;
using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class InvoiceController : Controller{
        public IActionResult Index(){
            var svc = new InvoiceService();
            var model = svc.GetAllInvoices();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(InvoiceCreate model){
            if (!ModelState.IsValid) return View(model);
                        
            var svc = new InvoiceService();
            if (svc.CreateInvoice(model)){
                TempData["SaveResult"] = "Invoice has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("InvoiceCreateFailed", "Something went wrong while attempting to create the Invoice, please try again.");
            return View(model);
        }

        public IActionResult Details(Guid id){
            var svc = new InvoiceService();
            var model = svc.GetInvoiceByID(id);
            return View(model);
        }        

        public IActionResult IndexByStatus(bool status){
            var svc = new InvoiceService();
            var model = svc.GetInvoicesByPaidStatus(status);
            return View(model);
        }

        public IActionResult IndexByDueSoon(){
            var svc = new InvoiceService();
            var model = svc.GetInvoicesDueSoon();
            return View(model);
        }

        public IActionResult IndexByPastDue(){
            var svc = new InvoiceService();
            var model = svc.GetOverdueInvoices();
            return View(model);
        }

        public IActionResult IndexByVendor(int vendorID){
            var svc = new InvoiceService();
            var model = svc.GetInvoicesByVendorID(vendorID);
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var svc = new InvoiceService();
            var detail = svc.GetInvoiceByID(id);
            var model = new InvoiceEdit{
                InvoiceID = detail.InvoiceID,
                InvoiceIsPaid = detail.InvoiceIsPaid,
                PaidDate = detail.PaidDate
            };
            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(Guid id, InvoiceEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.InvoiceID != id){
                ModelState.AddModelError("InvoiceIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new InvoiceService();
            if (svc.UpdateInvoice(model)){
                TempData["SaveResult"] = "Invoice information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("InvoiceEditFailed", "Something went wrong while attempting to update the Invoice information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var svc = new InvoiceService();
            var model = svc.GetInvoiceByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteInvoice(Guid id){
            var svc = new InvoiceService();
            svc.DeleteInvoice(id);
            TempData["SaveResult"] = "Invoice has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}