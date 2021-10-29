using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Services;
using SaintReverenceMVC.Services.ServiceContracts;

namespace SaintReverenceMVC.Controllers{
    public class CollectionController : Controller{
        private readonly ICollectionService _service;
        public CollectionController(ICollectionService service){
            _service = service;
        }

        // GET: Index
        public Task<IActionResult> Index(){
            var model = await _service.GetAllCollectionsAsync();
            return View(model);
        }

        // GET: Create 
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public Task<IActionResult> Create(CollectionCreate model){
            if (!ModelState.IsValid) return View(model);

            if (await _service.CreateCollectionAsync(model)){
                TempData["SaveResult"] = "Collection has been created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CreateCollectionFailed", "Something went wrong while attempting to create the Collection, please try again.");
            return View(model);
        }

        // GET: Details
        public Task<IActionResult> Details(int id){
            var model = await _service.GetCollectionByIDAsync(id);
            return View(model);
        }

        public Task<IActionResult> IndexByEndDate(){
            var model = await _service.GetCollectionsEndingSoonAsync();
            return View(model);
        }

        // GET: Edit
        public Task<IActionResult> Edit(int id){
            var details = await _service.GetCollectionByIDAsync(id);
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
        public Task<IActionResult> Edit(int id, CollectionEdit model){
            if (!ModelState.IsValid) return View(model);

            if (model.CollectionID != id){
                ModelState.AddModelError("CollectionIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            if (await _service.UpdateCollectionAsync(model)){
                TempData["SaveResult"] = "Collection information has been updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("CollectionUpdateFailed", "Something went wrong while attempting to update the Collection information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public Task<IActionResult> Delete(int id){
            var model = await _service.GetCollectionByIDAsync(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public Task<IActionResult> DeleteCollection(int id){
            await _service.DeleteCollectionAsync(id);
            TempData["SaveResult"] = "Collection has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}