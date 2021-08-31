using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class CollectionController : Controller{
        // GET: Index
        public IActionResult Index(){

            var svc = new CollectionService();
            var model = svc.GetAllCollections();
            return View(model);            
        }

        // GET: Create 
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(CollectionCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = new CollectionService();
            if (svc.CreateCollection(model)){
                TempData["SaveResult"] = "Collection has been created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CreateCollectionFailed", "Something went wrong while attempting to create the Collection, please try again.");
            return View(model);
        }

        // GET: Details
        public IActionResult Details(int id){
            var svc = new CollectionService();
            var model = svc.GetCollectionByID(id);
            return View(model);
        }

        public IActionResult IndexByEndDate(){
            var svc = new CollectionService();
            var model = svc.GetCollectionsEndingSoon();
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(int id){
            var svc = new CollectionService();
            var details = svc.GetCollectionByID(id);
            var model = new CollectionEdit{
                CollectionID = details.CollectionID,
                CollectionName = details.CollectionName,
                CollectionDescription = details.CollectionDescription,
                PublishDate = details.PublishDate,
                EndDate = details.EndDate
            };

            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(int id, CollectionEdit model){
            if (!ModelState.IsValid) return View(model);

            if (model.CollectionID != id){
                ModelState.AddModelError("CollectionIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new CollectionService();
            if (svc.UpdateCollection(model)){
                TempData["SaveResult"] = "Collection information has been updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CollectionUpdateFailed", "Something went wrong while attempting to update the Collection information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(int id){
            var svc = new CollectionService();
            var model = svc.GetCollectionByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteCollection(int id){
            var svc = new CollectionService();
            svc.DeleteCollection(id);
            TempData["SaveResult"] = "Collection has been successfully removed!";
            return Redirect(nameof(Index));
        }
    }
}