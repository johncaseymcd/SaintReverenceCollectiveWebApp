using System;
using Microsoft.AspNetCore.Mvc;
using SaintReverenceMVC.Models.ProductModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class ProductController : Controller{
        public IActionResult Index(){
            var svc = new ProductService();
            var model = svc.GetAllProducts();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(ProductCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = new ProductService();
            if (svc.CreateProduct(model)){
                TempData["SaveResult"] = "Product has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("ProductCreateFailed", "Something went wrong while attempting to create the Product, please try again.");
            return View(model);
        }

        public IActionResult Details(int id){
            var svc = new ProductService();
            var model = svc.GetProductByID(id);
            return View(model);
        }

        public IActionResult IndexByInStock(){
            var svc = new ProductService();
            var model = svc.GetProductsByInStock();
            return View(model);
        }

        public IActionResult IndexByStatus(bool status){
            var svc = new ProductService();
            var model = svc.GetProductsByStatus(status);
            return View(model);
        }

        public IActionResult IndexByCategory(int categoryID){
            var svc = new ProductService();
            var model = svc.GetProductsByCategory(categoryID);
            return View(model);
        }

        public IActionResult IndexByCollection(int collectionID){
            var svc = new ProductService();
            var model = svc.GetProductsByCollection(collectionID);
            return View(model);
        }

        public IActionResult AddProductToOrder(int productID, Guid orderID){
            var svc = new ProductService();
            if(svc.AddProductToOrder(productID, orderID)){
                TempData["SaveResult"] = "Product has been successfully added to order!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("AddProductToOrderFailed", "Something went wrong while attempting to add the product to the order, please try again.");
            return Details(productID);
        }

        // GET: Edit
        public IActionResult Edit(int id){
            var svc = new ProductService();
            var detail = svc.GetProductByID(id);
            var model = new ProductEdit{
                ProductID = detail.ProductID,
                ProductName = detail.ProductName,
                ProductDescription = detail.ProductDescription,
                ProductSellPrice = detail.ProductSellPrice,
                ProductInventoryCount = detail.ProductInventoryCount,
                ProductIsActive = detail.ProductIsActive
            };
            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(int id, ProductEdit model){
            if (!ModelState.IsValid) return View(model);
            if(model.ProductID != id){
                ModelState.AddModelError("ProductIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new ProductService();
            if(svc.UpdateProduct(model)){
                TempData["SaveResult"] = "Product information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("ProductEditFailed", "Something went wrong while attempting to update the Product information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(int id){
            var svc = new ProductService();
            var model = svc.GetProductByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteProduct(int id){
            var svc = new ProductService();
            svc.DeleteProduct(id);
            TempData["SaveResult"] = "Product has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}