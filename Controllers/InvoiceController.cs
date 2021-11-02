using System;
using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Services;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Controllers{
    public class InvoiceController : Controller{
        public async Task<IActionResult> Index(){
            var svc = new InvoiceService();
            var model = await svc.GetAllInvoicesAsync();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public async Task<IActionResult> Create(InvoiceCreate model){
            if (!ModelState.IsValid) return View(model);
                        
            var svc = new InvoiceService();
            if (await svc.CreateInvoiceAsync(model)){
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

        public async Task<IActionResult> IndexByStatus(bool status){
            var svc = new InvoiceService();
            var model = await svc.GetInvoicesByPaidStatusAsync(status);
            return View(model);
        }

        public async Task<IActionResult> IndexByDueSoon(){
            var svc = new InvoiceService();
            var model = await svc.GetInvoicesDueSoonAsync();
            return View(model);
        }

        public async Task<IActionResult> IndexByPastDue(){
            var svc = new InvoiceService();
            var model = await svc.GetOverdueInvoicesAsync();
            return View(model);
        }

        public async Task<IActionResult> IndexByVendor(int vendorID){
            var svc = new InvoiceService();
            var model = await svc.GetInvoicesByVendorIDAsync(vendorID);
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
        public async Task<IActionResult> Edit(Guid id, InvoiceEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.InvoiceID != id){
                ModelState.AddModelError("InvoiceIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new InvoiceService();
            if (await svc.UpdateInvoiceAsync(model)){
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
        public async Task<IActionResult> DeleteInvoice(Guid id){
            var svc = new InvoiceService();
            await svc.DeleteInvoiceAsync(id);
            TempData["SaveResult"] = "Invoice has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}